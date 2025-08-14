using MasterMemory;
using Newtonsoft.Json;
using System.CommandLine;
using System.Security.Cryptography;
using Wizard2AssetsUnpacker.Models;
using Wizard2AssetsUnpacker.Models.Generated;

namespace Wizard2AssetsUnpacker.Classes
{
    public class Manifest
    {
        public RangeView<AssetBundleLoadName> AssetBundleLoadName { get; set; }
        public RangeView<ManifestAsset> ManifestAsset { get; set; }
        public RangeView<ManifestConfig> ManifestConfig { get; set; }
        public RangeView<ManifestRawAsset> ManifestRawAsset { get; set; }

        public static Manifest FromMemoryDatabase(MemoryDatabase db)
        {
            return new Manifest()
            {
                AssetBundleLoadName = db.AssetBundleLoadNameTable.All,
                ManifestRawAsset = db.ManifestRawAssetTable.All,
                ManifestConfig = db.ManifestConfigTable.All,
                ManifestAsset = db.ManifestAssetTable.All,
            };
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ManifestCommand
    {
        public static MemoryDatabase Deserialize(byte[] bytes)
        {
            var dataLength = bytes.Length - MD5.HashSizeInBytes;
            var dataBytes = bytes.Take(dataLength).ToArray();
            var db = new MemoryDatabase(dataBytes, false);

            return db;
        }

        private static async Task<byte[]> Download(string version, LangType langType)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(string.Format(Config.Instance.ManifestAddress, version, langType.ToString()));
            var responseBytes = await response.Content.ReadAsByteArrayAsync();

            return responseBytes;
        }

        public static async Task<int> Invoke(string version, LangType langType, FormatOption formatOption)
        {
            var bytes = await Download(version, langType);
            var dest = $"./assetbundle.{langType}.manifest";

            switch (formatOption)
            {
                case FormatOption.Raw:
                    {
                        File.WriteAllBytes(dest, bytes);
                        break;
                    }
                case FormatOption.Json:
                    {
                        var db = Deserialize(bytes);
                        File.WriteAllText($"{dest}.json", Manifest.FromMemoryDatabase(db).Serialize());
                        break;
                    }
            }
            return 0;
        }

        public static Command GetCommand()
        {
            Command manifestCommand = new("manifest", "download manifest from server");
            Option<string> versionOption = new("--version")
            {
                Description = "The asset manifest version to download.",
                Required = true
            };
            Option<LangType> variantOption = new("--variant")
            {
                Description = $"The asset manifest variant to download.",
                DefaultValueFactory = _ => LangType.Chs
            };
            Option<FormatOption> formatOption = new("--format")
            {
                Description = $"The format when saving asset manifest.",
                DefaultValueFactory = _ => FormatOption.Raw
            };
            manifestCommand.Options.Add(versionOption);
            manifestCommand.Options.Add(variantOption);
            manifestCommand.Options.Add(formatOption);
            manifestCommand.SetAction(async args =>
            {
                await Invoke(args.GetValue(versionOption), args.GetValue(variantOption), args.GetValue(formatOption));
            });

            return manifestCommand;
        }

        // ─────────────────────────────────────────────────────────
        // NEW: convert a local raw manifest file → JSON
        // Usage:
        //   manifest-file --input ./assetbundle.Chs.manifest
        // Output:
        //   ./assetbundle.Chs.manifest.json
        // ─────────────────────────────────────────────────────────
        private static async Task<int> InvokeFromFile(string inputPath)
        {
            if (!File.Exists(inputPath))
                throw new FileNotFoundException("Input manifest not found", inputPath);

            var bytes = await File.ReadAllBytesAsync(inputPath);
            var db = Deserialize(bytes);
            var json = Manifest.FromMemoryDatabase(db).Serialize();
            File.WriteAllText(inputPath + ".json", json);
            return 0;
        }

        public static Command GetFileCommand()
        {
            Command cmd = new("manifest-file", "convert a downloaded raw manifest file to JSON");
            Option<string> inputOption = new("--input")
            {
                Description = "Path to the raw manifest file",
                Required = true
            };
            cmd.Options.Add(inputOption);
            cmd.SetAction(async args =>
            {
                await InvokeFromFile(args.GetValue(inputOption));
            });
            return cmd;
        }
    }
}

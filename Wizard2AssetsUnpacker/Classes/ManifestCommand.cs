using MasterMemory;
using MessagePack;
using Newtonsoft.Json;
using System.CommandLine;
using System.Security.Cryptography;
using Wizard2AssetsUnpacker.Models;

namespace Wizard2AssetsUnpacker.Classes
{
    [MemoryTable("asset"), MessagePackObject(false)]
    public record ManifestAsset
    {

        // Properties
        [Key(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        [PrimaryKey(0)]
        public string Name { get; set; }
        [Key(1)]
        [StringComparisonOption(StringComparison.Ordinal)]
        [SecondaryKey(0, 0)]
        public string Hash { get; set; }
        [Key(2)]
        [SecondaryKey(3, 0)]
        public int AssetId { get; set; }
        [Key(3)]
        public int[] AllDependencies { get; set; }
        [Key(4)]
        public long Key { get; set; }
        [Key(5)]
        public int Size { get; set; }
        [SecondaryKey(1, 0)]
        [NonUnique]
        [StringComparisonOption(StringComparison.Ordinal)]
        [Key(6)]
        public string Category { get; set; }
        [Key(7)]
        [SecondaryKey(2, 0)]
        [NonUnique]
        public int Group { get; set; }
        [Key(8)]
        public ulong CheckSum { get; set; }
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
                        File.WriteAllText($"{dest}.json", JsonConvert.SerializeObject(db.ManifestAssetTable.All));
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
    }
}

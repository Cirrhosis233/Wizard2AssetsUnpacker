using System.CommandLine;

namespace Wizard2AssetsUnpacker.Classes
{
    public class AssetCommand
    {
        private static Option<MemoryDatabase> manifestOption = new("--manifest")
        {
            Description = "The path of asset manifest to get decrypt key",
            Required = true,
            CustomParser = result =>
            {
                if (result.Tokens.Count == 0)
                {
                    return ManifestCommand.Deserialize(File.ReadAllBytes("./assetbundle.Chs.manifest"));
                }
                string filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.AddError("File does not exist");
                    return null;
                }
                else
                {
                    return ManifestCommand.Deserialize(File.ReadAllBytes(filePath));
                }
            },
        };

        public class AssetDecryptCommand
        {
            public static int Invoke(string path, MemoryDatabase manifestDB)
            {
                var length = new FileInfo(path).Length;
                var buffer = new byte[length];
                var stream = new AssetBundleStream(path, manifestDB.ManifestAssetTable.FindByHash(Path.GetFileName(path)).Key);
                stream.Read(buffer, 0, (int)length);

                var fileName = Path.GetFileNameWithoutExtension(path);
                var decryptedPath = path.Replace(fileName, $"{fileName}_decrypted");
                var dest = Path.HasExtension(decryptedPath) ? decryptedPath : Path.ChangeExtension(decryptedPath, ".ab");
                File.WriteAllBytes(dest, buffer);

                return 0;
            }

            public static Command GetCommand()
            {
                Command assetDecryptCommand = new("decrypt", "decrypt assetbundles");
                Option<string> pathOption = new("--file")
                {
                    Description = "The path of encrypted assetbundle file",
                    Required = true,
                };
                assetDecryptCommand.Options.Add(pathOption);
                assetDecryptCommand.Options.Add(manifestOption);

                assetDecryptCommand.SetAction(args =>
                {
                    Invoke(args.GetValue(pathOption), args.GetValue(manifestOption));
                });

                return assetDecryptCommand;
            }
        }

        public class AssetDownloadCommand
        {
            public static async Task<int> Invoke(string name, MemoryDatabase manifestDB)
            {
                var hName = manifestDB.ManifestAssetTable.FindByName(name).Hash;
                var downloadPath = Path.Combine(hName[..2], hName);

                var httpClient = new HttpClient();
                var uri = string.Format(Config.Instance.AssetBundleAddress, hName[..2], hName);
                var response = await httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var responseBytes = await response.Content.ReadAsByteArrayAsync();
                File.WriteAllBytes(hName, responseBytes);

                return 0;
            }

            public static Command GetCommand()
            {
                Command assetDownloadCommand = new("download", "download assetbundles");
                Argument<string> nameArgument = new("name")
                {
                    Description = "The asset name to download, can be found in manifest"
                };
                assetDownloadCommand.Arguments.Add(nameArgument);
                assetDownloadCommand.Options.Add(manifestOption);

                assetDownloadCommand.SetAction(async args =>
                {
                    await Invoke(args.GetValue(nameArgument), args.GetValue(manifestOption));
                });

                return assetDownloadCommand;
            }
        }


        public static Command GetCommand()
        {
            Command assetCommand = new("asset", "download and decrypt assetbundles");
            assetCommand.Subcommands.Add(AssetDecryptCommand.GetCommand());
            assetCommand.Subcommands.Add(AssetDownloadCommand.GetCommand());

            return assetCommand;
        }
    }
}

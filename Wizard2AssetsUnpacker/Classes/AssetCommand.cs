using System.CommandLine;

namespace Wizard2AssetsUnpacker.Classes
{
    public class AssetCommand
    {
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
                assetDecryptCommand.Options.Add(OptionsManager.ManifestOption);

                assetDecryptCommand.SetAction(args =>
                {
                    Invoke(args.GetValue(pathOption), args.GetValue(OptionsManager.ManifestOption));
                });

                return assetDecryptCommand;
            }
        }

        public class AssetDownloadCommand
        {
            public static async Task<int> Invoke(string name, MemoryDatabase manifestDB)
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(Utils.GetDownloadUriByName(manifestDB, name));
                response.EnsureSuccessStatusCode();

                var responseBytes = await response.Content.ReadAsByteArrayAsync();
                var dest = Path.Combine("Downloaded", name);
                var destDir = Path.GetDirectoryName(dest);
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                File.WriteAllBytes(dest, responseBytes);

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
                assetDownloadCommand.Options.Add(OptionsManager.ManifestOption);

                assetDownloadCommand.SetAction(async args =>
                {
                    await Invoke(args.GetValue(nameArgument), args.GetValue(OptionsManager.ManifestOption));
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

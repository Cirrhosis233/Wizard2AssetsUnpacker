using Newtonsoft.Json;
using System.CommandLine;
using Wizard2AssetsUnpacker.Classes;

namespace Wizard2AssetsUnpacker
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (!File.Exists(Constants.ConfigPath))
            {
                File.WriteAllText(Constants.ConfigPath, JsonConvert.SerializeObject(new Config(), Formatting.Indented));
            }

            RootCommand rootCommand = new("Unpacker for Shadowverse: Worlds Beyond");
            rootCommand.Subcommands.Add(ManifestCommand.GetCommand());
            rootCommand.Subcommands.Add(VersionCommand.GetCommand());
            rootCommand.Subcommands.Add(AssetCommand.GetCommand());
            rootCommand.Subcommands.Add(MasterDataCommand.GetCommand());

            return rootCommand.Parse(args).Invoke();
        }
    }
}

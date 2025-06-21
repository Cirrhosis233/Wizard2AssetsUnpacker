using Newtonsoft.Json;
using System.CommandLine;

namespace Wizard2AssetsUnpacker.Classes
{
    public class MasterDataCommand
    {
        private static readonly List<string> ExcludedTables = [
            "AssetBundleLoadNameTable",
            "ManifestAssetTable",
            "ManifestConfigTable",
            "ManifestRawAssetTable",
            "LocalizeTextTable"
        ];

        public static async Task<int> Invoke(MemoryDatabase manifestDB)
        {
            var uri = Utils.GetDownloadUriByName(manifestDB, "Master/mastermemory.bytes");
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var responseBytes = await response.Content.ReadAsByteArrayAsync();

            if (!Directory.Exists("./MasterDataCaches"))
            {
                Directory.CreateDirectory("./MasterDataCaches");
            }
            File.WriteAllBytes("./MasterDataCaches/mastermemory.bytes", responseBytes);

            var masterDatabase = new MemoryDatabase(
                responseBytes,
                false,
                MessagePack.Resolvers.CompositeResolver.Create([
                    MasterMemoryResolver.Instance,
                    MessagePack.GeneratedMessagePackResolver.Instance,
                    MessagePack.Resolvers.StandardResolver.Instance
                ]));

            var type = masterDatabase.GetType();
            var ctor = type.GetConstructors()[0];
            if (!Directory.Exists("./MasterData"))
            {
                Directory.CreateDirectory("./MasterData");
            }

            foreach (var param in ctor.GetParameters())
            {
                var tableName = param.ParameterType.Name;
                if (ExcludedTables.Contains(tableName)) continue;
                var table = masterDatabase.GetType().GetProperty(tableName).GetValue(masterDatabase, null);
                var tableView = table.GetType().GetProperty("All").GetValue(table, null);
                File.WriteAllText($"./MasterData/{tableName}.json", JsonConvert.SerializeObject(tableView, Formatting.Indented));
            }

            return 0;
        }

        public static Command GetCommand()
        {
            Command masterDataCommand = new("master", "unpack master data");
            masterDataCommand.Options.Add(OptionsManager.ManifestOption);

            masterDataCommand.SetAction(async args =>
            {
                await Invoke(args.GetValue(OptionsManager.ManifestOption));
            });

            return masterDataCommand;
        }
    }
}

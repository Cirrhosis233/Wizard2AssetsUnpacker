using Newtonsoft.Json;
using System.CommandLine;

namespace Wizard2AssetsUnpacker.Classes
{
    public class LocalizeCommand
    {
        public static void Invoke(string path)
        {
            var db = new MemoryDatabase(File.ReadAllBytes(path), false);
            File.WriteAllText(Path.ChangeExtension(path, ".json"), JsonConvert.SerializeObject(db.LocalizeTextTable.All));
        }

        public static Command GetCommand()
        {
            Command masterDataCommand = new("localize", "unpack localize data");
            Option<string> pathOption = new("--file")
            {
                Description = "The path of serialized localize file",
                Required = true,
            };
            masterDataCommand.Options.Add(pathOption);

            masterDataCommand.SetAction(args =>
            {
                Invoke(args.GetValue(pathOption));
            });

            return masterDataCommand;
        }
    }
}

using SQLitePCL;
using System.CommandLine;
using static SQLitePCL.raw;

namespace Wizard2AssetsUnpacker.Classes
{
    public class MetaDBCommand
    {
        static MetaDBCommand()
        {
            Batteries_V2.Init();
        }

        public static void Invoke(string path)
        {
            File.Copy(path, "./meta.db");
            var rc = sqlite3_open("meta.db", out var db);
            if (rc != SQLITE_OK) throw new Exception($"sqlite3_open() returned: {rc}");
            using (db)
            {
                var key = Convert.FromBase64String(Config.Instance.Sqlite3mcKey);
                var baseKey = Convert.FromBase64String(Config.Instance.Sqlite3mcBaseKey);
                var finalKey = new byte[key.Length];

                var v3 = key.Length;
                for (var i = 0; i < key.Length; i++)
                {
                    finalKey[i] = (byte)(key[i] ^ baseKey[i % 0xD]);
                }

                var name = utf8z.FromString("main");
                rc = sqlite3_key_v2(db, name, finalKey);
                if (rc != SQLITE_OK) throw new Exception($"sqlite3_key_v2() returned: {rc}");

                rc = sqlite3_rekey_v2(db, name, null);
                if (rc != SQLITE_OK) throw new Exception($"sqlite3_rekey_v2() returned: {rc}");
            }

        }

        public static Command GetCommand()
        {
            Command metaDBCommand = new("metadb", "decrypt game created meta database");
            Argument<string> pathArgument = new("path")
            {
                Description = "The path to the meta database created by the game"
            };
            metaDBCommand.Arguments.Add(pathArgument);
            metaDBCommand.SetAction(args =>
            {
                Invoke(args.GetValue(pathArgument));
            });

            return metaDBCommand;
        }
    }
}

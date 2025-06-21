using System.CommandLine;

namespace Wizard2AssetsUnpacker.Classes
{
    public class OptionsManager
    {
        public static Option<MemoryDatabase> ManifestOption = new("--manifest")
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
    }
}

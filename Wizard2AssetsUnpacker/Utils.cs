using Wizard2AssetsUnpacker.Models.Generated;

namespace Wizard2AssetsUnpacker
{
    public class Utils
    {
        public static string GetDownloadUriByName(MemoryDatabase db, string name)
        {
            string hName;

            if (db.ManifestAssetTable.TryFindByName(name, out ManifestAsset asset))
            {
                hName = asset.Hash;
            }
            else if (db.ManifestRawAssetTable.TryFindByName(name, out ManifestRawAsset rawAsset))
            {
                hName = rawAsset.Hash;
            }
            else
            {
                return null;
            }

            var downloadPath = Path.Combine(hName[..2], hName);
            var uri = string.Format(Config.Instance.AssetBundleAddress, hName[..2], hName);

            return uri;
        }
    }
}

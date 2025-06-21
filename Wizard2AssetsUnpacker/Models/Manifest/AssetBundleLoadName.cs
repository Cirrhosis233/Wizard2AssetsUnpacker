using MasterMemory;
using MessagePack;

namespace Wizard2AssetsUnpacker.Models.AssetBundle
{
    [MemoryTable("assetname"), MessagePackObject(false)]
    [Serializable]
    public class AssetBundleLoadName
    {
        [Key(0)]
        [PrimaryKey(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        public string AssetName { get; set; }
        [NonUnique]
        [SecondaryKey(1, 0)]
        [Key(1)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        public string Name { get; set; }
    }
}

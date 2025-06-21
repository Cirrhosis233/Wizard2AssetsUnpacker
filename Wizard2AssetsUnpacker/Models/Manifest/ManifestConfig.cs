using MasterMemory;
using MessagePack;

namespace Wizard2AssetsUnpacker.Models.AssetBundle
{
    [MemoryTable("config"), MessagePackObject(false)]
    [Serializable]
    public class ManifestConfig
    {
        [PrimaryKey(0)]
        [Key(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        public string Key { get; set; }
        [Key(1)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        [NonUnique]
        [SecondaryKey(1, 0)]
        public string Value { get; set; }
    }
}

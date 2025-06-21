using MasterMemory;
using MessagePack;

namespace Wizard2AssetsUnpacker.Models.AssetBundle
{
    [MemoryTable("raw_asset"), MessagePackObject(false)]
    [Serializable]
    public class ManifestRawAsset
    {
        [Key(0)]
        [PrimaryKey(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        public string Name { get; set; }
        [Key(1)]
        [StringComparisonOption(StringComparison.Ordinal)]
        [SecondaryKey(0, 0)]
        public string Hash { get; set; }
        [Key(2)]
        public int Size { get; set; }
        [StringComparisonOption(StringComparison.Ordinal)]
        [NonUnique]
        [Key(3)]
        [SecondaryKey(1, 0)]
        public string Category { get; set; }
        [SecondaryKey(2, 0)]
        [Key(4)]
        [NonUnique]
        public int Group { get; set; }
        [Key(5)]
        public ulong CheckSum { get; set; }
    }
}

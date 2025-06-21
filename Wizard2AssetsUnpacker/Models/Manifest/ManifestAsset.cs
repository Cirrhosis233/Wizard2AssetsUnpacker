using MasterMemory;
using MessagePack;

namespace Wizard2AssetsUnpacker.Models.AssetBundle
{
    [MemoryTable("asset"), MessagePackObject(false)]
    [Serializable]
    public class ManifestAsset
    {
        [Key(0)]
        [StringComparisonOption(StringComparison.OrdinalIgnoreCase)]
        [PrimaryKey(0)]
        public string Name { get; set; }
        [Key(1)]
        [StringComparisonOption(StringComparison.Ordinal)]
        [SecondaryKey(0, 0)]
        public string Hash { get; set; }
        [Key(2)]
        [SecondaryKey(3, 0)]
        public int AssetId { get; set; }
        [Key(3)]
        public int[] AllDependencies { get; set; }
        [Key(4)]
        public long Key { get; set; }
        [Key(5)]
        public int Size { get; set; }
        [SecondaryKey(1, 0)]
        [NonUnique]
        [StringComparisonOption(StringComparison.Ordinal)]
        [Key(6)]
        public string Category { get; set; }
        [Key(7)]
        [SecondaryKey(2, 0)]
        [NonUnique]
        public int Group { get; set; }
        [Key(8)]
        public ulong CheckSum { get; set; }
    }
}

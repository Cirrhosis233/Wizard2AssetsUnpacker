using Newtonsoft.Json;

namespace Wizard2AssetsUnpacker
{
    public class DeviceInfo
    {
        public string Platform { get; set; }
        public string Device { get; set; }
        public string DeviceName { get; set; }
        public string PlatformOSVersion { get; set; }
        public string GPUVendor { get; set; }
        public string GraphicsMemoryMB { get; set; }
        public string ProcessorType { get; set; }
    }

    public class Config
    {
        public string CommonHeader { get; set; }
        public string RoutingHeader { get; set; }
        public DeviceInfo DeviceInfo { get; set; }
        public string AppVersion { get; set; }
        public string DeviceUUID { get; set; }
        public string MD5Salt { get; set; }
        public string AssetBundleBaseKeys { get; set; }
        public long ClientId { get; set; }
        public string AssetBundleAddress { get; set; }
        public string ManifestAddress { get; set; }
        public string VersionAddress { get; set; }

        private static readonly Lazy<Config> lazy = new(() => JsonConvert.DeserializeObject<Config>(File.ReadAllText(Constants.ConfigPath))!);

        public static Config Instance { get { return lazy.Value; } }
    }
}

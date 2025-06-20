using MessagePack;

namespace Wizard2AssetsUnpacker.Models
{
    [MessagePackObject(false)]
    public class RequestCommon
    {
        [Key("uuid")]
        public string uuid;
        [Key("client_id")]
        public long client_id;
    }
}

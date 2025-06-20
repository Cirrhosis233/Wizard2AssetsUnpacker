using MessagePack;

namespace Wizard2AssetsUnpacker.Models
{
    [MessagePackObject(false)]
    public class ResponseCommon
    {
        [Key("data_headers")]
        public DataHeader data_headers;
    }
}

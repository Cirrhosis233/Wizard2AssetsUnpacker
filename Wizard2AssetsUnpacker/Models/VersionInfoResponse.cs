using MessagePack;

namespace Wizard2AssetsUnpacker.Models
{
    [MessagePackObject(false)]
    public class VersionInfoResponse : ResponseCommon
    {
        [MessagePackObject(false)]
        public class ResponseData
        {
            [Key("resource_version")]
            public string resource_version;
            [Key("epic_deployment_id")]
            public string epic_deployment_id;
            [Key("epic_sandbox_id")]
            public string epic_sandbox_id;
            [Key("portal_endpoint_url")]
            public string portal_endpoint_url;

        }

        [Key("data")]
        public ResponseData data;
    }
}

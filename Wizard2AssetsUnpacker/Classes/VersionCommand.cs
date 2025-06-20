using LibConeshell;
using MessagePack;
using System.CommandLine;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Wizard2AssetsUnpacker.Models;

namespace Wizard2AssetsUnpacker.Classes
{
    public class VersionCommand
    {
        private static string GetSessionID()
        {
            return MakeMD5(string.Concat(Config.Instance.ClientId, Config.Instance.DeviceUUID));
        }

        private static Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string> {
                { "SID", GetSessionID() },
                { "RES-VER", "00000000" },
                { "APP-VER", Config.Instance.AppVersion },
                { "Client-ID", Config.Instance.ClientId.ToString() },
                { "Platform", Config.Instance.DeviceInfo.Platform },
                { "Device", Config.Instance.DeviceInfo.Device },
                { "Routing-Header", Config.Instance.RoutingHeader},
                { "device-name", Config.Instance.DeviceInfo.DeviceName},
                { "platform-os-version", Config.Instance.DeviceInfo.PlatformOSVersion },
                { "gpu-vendor", Config.Instance.DeviceInfo.GPUVendor },
                { "graphics-memory-mb", Config.Instance.DeviceInfo.GraphicsMemoryMB },
                { "processor-type", Config.Instance.DeviceInfo.ProcessorType }
            };
        }

        private static void AddHeaders(HttpRequestMessage request, Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        private static string MakeMD5(string input)
        {
            MD5 md5 = MD5.Create();
            var content = Encoding.UTF8.GetBytes(string.Concat(input, Config.Instance.MD5Salt));
            var hashed = md5.ComputeHash(content);

            var result = new StringBuilder();
            foreach (var item in hashed)
            {
                result.Append(item.ToString("x2"));
            }

            return result.ToString();
        }

        public static async Task<int> Invoke(FormatOption formatOption)
        {
            var coneShell = ConeshellV4.FromCommonHeader(
                Convert.FromBase64String(Config.Instance.CommonHeader),
                Convert.FromHexString(Config.Instance.DeviceUUID.Replace("-", "")),
                Convert.FromHexString(GetSessionID())
            );
            var requestData = coneShell.EncryptRequest(MessagePackSerializer.Serialize(new VersionInfoRequest
            {
                uuid = "",
                client_id = Config.Instance.ClientId,
            }));

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, Config.Instance.VersionAddress);
            AddHeaders(request, GetHeaders());

            request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(Convert.ToBase64String(requestData.Data)));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-msgpack");

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseText = await response.Content.ReadAsStringAsync();
            var decrypted = coneShell.DecryptResponse(Convert.FromBase64String(responseText), ref requestData);

            switch (formatOption)
            {
                case FormatOption.Raw:
                    {
                        File.WriteAllBytes("./VersionInfo.bin", decrypted);
                        break;
                    }
                case FormatOption.Json:
                    {
                        var jsonInfo = MessagePackSerializer.ConvertToJson(decrypted);
                        File.WriteAllText("./VersionInfo.json", jsonInfo);
                        break;
                    }
            }

            return 0;
        }

        public static Command GetCommand()
        {
            Command versionCommand = new("version", "fetch current assets and assets manifest version");
            Option<FormatOption> formatOption = new("--format")
            {
                Description = $"The format when saving asset manifest.",
                DefaultValueFactory = _ => FormatOption.Json
            };
            versionCommand.Options.Add(formatOption);
            versionCommand.SetAction(async args =>
            {
                await Invoke(args.GetValue(formatOption));
            });

            return versionCommand;
        }
    }
}

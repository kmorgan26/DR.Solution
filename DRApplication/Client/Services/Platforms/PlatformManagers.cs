using DRApplication.Shared.Models;
namespace DRApplication.Client.Services.Platforms
{
    public class DeviceManager : ApiRepository<Device>
    {
        private readonly HttpClient _http;

        public DeviceManager(HttpClient http) : base(http, "device", "Id")
        {
            _http = http;
        }
    }
    public class DeviceTypeManager : ApiRepository<DeviceType>
    {
        private readonly HttpClient _http;
        static string controllerName = "devicetype";

        public DeviceTypeManager(HttpClient http) : base(http, controllerName, "Id")
        {
            _http = http;
        }
    }
    public class MaintainerManager : ApiRepository<Maintainer>
    {
        HttpClient _http;
        static string controllerName = "maintainer";

        public MaintainerManager(HttpClient http) : base(http, controllerName, "Id")
        {
            _http = http;
        }
    }

}

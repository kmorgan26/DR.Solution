using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Services.Device
{
    public class DeviceTypeManager: ApiRepository<DeviceType>
    {
        private readonly HttpClient _http;

        public DeviceTypeManager(HttpClient http) : base(http, "devicetype", "Id")
        {
            _http = http;
        }
    }
}

using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services.Configuration
{
    public class HardwareConfigManager : ApiRepository<HardwareConfig>
    {
        HttpClient http;

        public HardwareConfigManager(HttpClient _http) : base(_http, "hardwareconfig", "Id")
        {
            http = _http;
        }
    }
}

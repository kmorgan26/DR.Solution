using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services.Configurations
{
    public class HardwareConfigManager : ApiRepository<HardwareConfig>
    {
        private readonly HttpClient http;

        public HardwareConfigManager(HttpClient _http) : base(_http, "hardwareconfig", "Id")
        {
            http = _http;
        }
    }
}

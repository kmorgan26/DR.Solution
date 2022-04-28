using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services.Configurations
{
    public class HardwareConfigManager : ApiRepository<HardwareConfig>
    {
        private readonly HttpClient _http;

        public HardwareConfigManager(HttpClient http) : base(http, "hardwareconfig", "Id")
        {
            _http = http;
        }
    }
}

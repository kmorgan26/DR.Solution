using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services.Configurations
{
    public class HardwareVersionsConfigManager : ApiRepository<HardwareVersionsConfig>
    {
        private readonly HttpClient _http;

        public HardwareVersionsConfigManager(HttpClient http) : base(http, "hardwareversionsconfig", "Id")
        {
            _http = http;
        }
    }
}

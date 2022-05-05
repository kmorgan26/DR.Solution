using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services.Configurations
{
    public class HardwareSystemManager : ApiRepository<HardwareConfig>
    {
        private readonly HttpClient _http;

        public HardwareSystemManager(HttpClient http) : base(http, "hardwaresystem", "Id")
        {
            _http = http;
        }
    }
}

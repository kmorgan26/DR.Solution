using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services.Configurations
{
    public class SoftwareSystemManager : ApiRepository<SoftwareSystem>
    {
        private readonly HttpClient _http;

        public SoftwareSystemManager(HttpClient http) : base(http, "softwaresystem", "Id")
        {
            _http = http;
        }
    }
}

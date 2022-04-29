using AvnRepository;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Services.Platforms.Maintainers
{
    public class MaintainerManager : ApiEfRepository<Maintainer>
    {
        HttpClient _http;
        static string controllerName = "maintainer";

        public MaintainerManager(HttpClient http) : base(http, controllerName, "Id")
        {
            _http = http;
        }
    }
}

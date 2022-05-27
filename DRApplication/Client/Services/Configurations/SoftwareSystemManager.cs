using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services;

public class SoftwareSystemManager : ApiRepository<SoftwareSystem>
{
    private readonly HttpClient _http;

    public SoftwareSystemManager(HttpClient http) : base(http, "softwaresystem", "Id")
    {
        _http = http;
    }
}

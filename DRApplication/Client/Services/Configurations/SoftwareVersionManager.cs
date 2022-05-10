using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Services.Configurations;

public class SoftwareVersionManager : ApiRepository<SoftwareVersion>
{
    private readonly HttpClient _http;

    public SoftwareVersionManager(HttpClient http) : base(http, "softwareversion", "Id")
    {
        _http = http;
    }
}
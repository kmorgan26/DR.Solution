using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Services;

public class VersionsLoadManager : ApiRepository<VersionsLoad>
{
    private readonly HttpClient _http;

    public VersionsLoadManager(HttpClient http) : base(http, "versionsload", "Id")
    {
        _http = http;
    }
}
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class SpecificLoadManager : ApiRepository<SpecificLoad>
{
    private readonly HttpClient _http;

    public SpecificLoadManager(HttpClient http) : base(http, "specificload", "Id")
    {
        _http = http;
    }
}
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class CurrentLoadManager : ApiRepository<CurrentLoad>
{
    private readonly HttpClient _http;

    public CurrentLoadManager(HttpClient http) : base(http, "currentload", "Id")
    {
        _http = http;
    }
}
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class LoadManager : ApiRepository<Load>
{
    private readonly HttpClient _http;

    public LoadManager(HttpClient http) : base(http, "load", "Id")
    {
        _http = http;
    }
}
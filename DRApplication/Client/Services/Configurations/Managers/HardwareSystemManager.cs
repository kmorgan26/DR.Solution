using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class HardwareSystemManager : ApiRepository<HardwareSystem>
{
    private readonly HttpClient _http;

    public HardwareSystemManager(HttpClient http) : base(http, "hardwaresystem", "Id")
    {
        _http = http;
    }
}

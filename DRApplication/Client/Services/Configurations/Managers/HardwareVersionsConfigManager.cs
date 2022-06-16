using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class HardwareVersionsConfigManager : ApiRepository<HardwareVersionsConfig>
{
    private readonly HttpClient _http;

    public HardwareVersionsConfigManager(HttpClient http) : base(http, "hardwareversionsconfig", "Id")
    {
        _http = http;
    }
}

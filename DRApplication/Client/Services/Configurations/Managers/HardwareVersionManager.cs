
using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Services;

public class HardwareVersionManager : ApiRepository<HardwareVersion>
{
    private readonly HttpClient _http;

    public HardwareVersionManager(HttpClient http) : base(http, "hardwareversion", "Id")
    {
        _http = http;
    }
}


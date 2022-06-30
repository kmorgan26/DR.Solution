using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;
public class DeviceDiscoveredManager : ApiRepository<DeviceDiscovered>
{
    private readonly HttpClient _http;

    public DeviceDiscoveredManager(HttpClient http) : base(http, "devicediscovered", "Id")
    {
        _http = http;
    }
}

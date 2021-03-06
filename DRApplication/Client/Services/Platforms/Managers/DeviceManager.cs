using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class DeviceManager : ApiRepository<Device>
{
    private readonly HttpClient _http;

    public DeviceManager(HttpClient http) : base(http, "device", "Id")
    {
        _http = http;
    }
}

using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class DeviceTypeManager: ApiRepository<DeviceType>
{
    private readonly HttpClient _http;
    static string controllerName = "devicetype";

    public DeviceTypeManager(HttpClient http) : base(http, controllerName, "Id")
    {
        _http = http;
    }
}

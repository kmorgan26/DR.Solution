using DRApplication.Client.ViewModels;
namespace DRApplication.Client.Services;

public class DeviceVmManager : AdHocRepository<DeviceVm>
{
    private readonly HttpClient _http;

    public DeviceVmManager(HttpClient http) : base(http)
    {
        _http = http;
    }
}

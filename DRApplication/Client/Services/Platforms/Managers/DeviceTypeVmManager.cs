using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Services;

public class DeviceTypeVmManager : AdHocRepository<DeviceTypeVm>
{
    private readonly HttpClient _httpClient;

    public DeviceTypeVmManager(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}

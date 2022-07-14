using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Services;
public class CurrentLoadVmManager : AdHocRepository<CurrentLoadVm>
{
    private readonly HttpClient _httpClient;

    public CurrentLoadVmManager(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
public class LoadVmManager : AdHocRepository<LoadVm>
{
    private readonly HttpClient _httpClient;

    public LoadVmManager(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
public class VersionsLoadVmManager : AdHocRepository<VersionsLoadVm>
{
    private readonly HttpClient _httpClient;

    public VersionsLoadVmManager(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
public class SpecificLoadVmManager : AdHocRepository<SpecificLoadVm>
{
    private readonly HttpClient _httpClient;

    public SpecificLoadVmManager(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
public class DeviceTypeVmManager : AdHocRepository<DeviceTypeVm>
{
    private readonly HttpClient _httpClient;

    public DeviceTypeVmManager(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}

public class DeviceVmManager : AdHocRepository<DeviceVm>
{
    private readonly HttpClient _http;

    public DeviceVmManager(HttpClient http) : base(http)
    {
        _http = http;
    }
}
public class HardwareSystemVmManager : AdHocRepository<HardwareSystemVm>
{
    private readonly HttpClient _http;

    public HardwareSystemVmManager(HttpClient http) : base(http)
    {
        _http = http;
    }
}
public class HardwareVersionVmManager: AdHocRepository<HardwareVersionVm>
{
    private readonly HttpClient _http;

    public HardwareVersionVmManager(HttpClient http) : base(http)
    {
        _http = http;
    }
}
public class HardwareConfigVmManager : AdHocRepository<HardwareConfigVm>
{
    private readonly HttpClient _http;

    public HardwareConfigVmManager(HttpClient http) : base(http)
    {
        _http = http;
    }
}


public class SoftwareSystemVmManager : AdHocRepository<SoftwareSystemVm>
{
    private readonly HttpClient _http;

    public SoftwareSystemVmManager(HttpClient http) : base(http)
    {
        _http = http;
    }
}
public class SoftwareVersionVmManager : AdHocRepository<SoftwareVersionVm>
{
    private readonly HttpClient _http;

    public SoftwareVersionVmManager(HttpClient http) : base(http)
    {
        _http = http;
    }
}
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
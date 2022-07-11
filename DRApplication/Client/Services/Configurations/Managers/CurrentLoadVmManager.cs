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

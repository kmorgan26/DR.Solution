using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class MaintainerManager : ApiRepository<Maintainer>
{
    HttpClient _http;
    static string controllerName = "maintainer";

    public MaintainerManager(HttpClient http) : base(http, controllerName, "Id")
    {
        _http = http;
    }
}

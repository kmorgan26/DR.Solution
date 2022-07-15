using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class CorrectiveActionManager : ApiRepository<CorrectiveAction>
{
    private readonly HttpClient _http;

    public CorrectiveActionManager(HttpClient http) : base(http, "correctiveaction", "Id")
    {
        _http = http;
    }
}
public class DeviceDiscoveredManager : ApiRepository<DeviceDiscovered>
{
    private readonly HttpClient _http;

    public DeviceDiscoveredManager(HttpClient http) : base(http, "devicediscovered", "Id")
    {
        _http = http;
    }
}
public class DrManager : ApiRepository<Dr>
{
    private readonly HttpClient _http;

    public DrManager(HttpClient http) : base(http, "dr", "Id")
    {
        _http = http;
    }
}
public class IssueManager : ApiRepository<Issue>
{
    private readonly HttpClient _http;

    public IssueManager(HttpClient http) : base(http, "issue", "Id")
    {
        _http = http;
    }
}
public class MaintIssueManager : ApiRepository<MaintIssue>
{
    private readonly HttpClient _http;

    public MaintIssueManager(HttpClient http) : base(http, "maintissue", "Id")
    {
        _http = http;
    }
}

using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class MaintIssueManager : ApiRepository<MaintIssue>
{
    private readonly HttpClient _http;

    public MaintIssueManager(HttpClient http) : base(http, "maintissue", "Id")
    {
        _http = http;
    }
}

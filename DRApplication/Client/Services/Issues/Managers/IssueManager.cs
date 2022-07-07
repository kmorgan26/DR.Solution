using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class IssueManager : ApiRepository<Issue>
{
    private readonly HttpClient _http;

    public IssueManager(HttpClient http) : base(http, "issue", "Id")
    {
        _http = http;
    }
}

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

using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class DrManager : ApiRepository<Dr>
{
    private readonly HttpClient _http;

    public DrManager(HttpClient http) : base(http, "dr", "Id")
    {
        _http = http;
    }
}

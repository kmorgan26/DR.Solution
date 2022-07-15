using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class CurrentLoadManager : ApiRepository<CurrentLoad>
{
    private readonly HttpClient _http;

    public CurrentLoadManager(HttpClient http) : base(http, "currentload", "Id")
    {
        _http = http;
    }
}
public class HardwareConfigManager : ApiRepository<HardwareConfig>
{
    private readonly HttpClient _http;

    public HardwareConfigManager(HttpClient http) : base(http, "hardwareconfig", "Id")
    {
        _http = http;
    }
}
public class HardwareSystemManager : ApiRepository<HardwareSystem>
{
    private readonly HttpClient _http;

    public HardwareSystemManager(HttpClient http) : base(http, "hardwaresystem", "Id")
    {
        _http = http;
    }
}
public class HardwareVersionManager : ApiRepository<HardwareVersion>
{
    private readonly HttpClient _http;

    public HardwareVersionManager(HttpClient http) : base(http, "hardwareversion", "Id")
    {
        _http = http;
    }
}
public class HardwareVersionsConfigManager : ApiRepository<HardwareVersionsConfig>
{
    private readonly HttpClient _http;

    public HardwareVersionsConfigManager(HttpClient http) : base(http, "hardwareversionsconfig", "Id")
    {
        _http = http;
    }
}
public class LoadManager : ApiRepository<Load>
{
    private readonly HttpClient _http;

    public LoadManager(HttpClient http) : base(http, "load", "Id")
    {
        _http = http;
    }
}
public class SoftwareSystemManager : ApiRepository<SoftwareSystem>
{
    private readonly HttpClient _http;

    public SoftwareSystemManager(HttpClient http) : base(http, "softwaresystem", "Id")
    {
        _http = http;
    }
}
public class SoftwareVersionManager : ApiRepository<SoftwareVersion>
{
    private readonly HttpClient _http;

    public SoftwareVersionManager(HttpClient http) : base(http, "softwareversion", "Id")
    {
        _http = http;
    }
}
public class SpecificLoadManager : ApiRepository<SpecificLoad>
{
    private readonly HttpClient _http;

    public SpecificLoadManager(HttpClient http) : base(http, "specificload", "Id")
    {
        _http = http;
    }
}
public class VersionsLoadManager : ApiRepository<VersionsLoad>
{
    private readonly HttpClient _http;

    public VersionsLoadManager(HttpClient http) : base(http, "versionsload", "Id")
    {
        _http = http;
    }
}
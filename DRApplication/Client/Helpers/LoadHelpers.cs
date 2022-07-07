using DRApplication.Client.Interfaces;
using DRApplication.Client.Services;
using DRApplication.Shared.Models;
namespace DRApplication.Client.Helpers;

public class LoadHelpers : ILoadHelpers
{
    private readonly IManagerService _managerService;

    public LoadHelpers(IManagerService managerService)
    {
        _managerService = managerService;
    }

    public async Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsFromVersionLoads(IEnumerable<VersionsLoad> versionsLoads)
    {
        var softwareVersionIds = versionsLoads.Select(x => x.SoftwareVersionId.ToString()).ToList();
        var softwareVersionFilter = new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByListOfIds("Id", softwareVersionIds);
        var softwareVersionResponse = await _managerService.SoftwareVersionManager().GetAsync(softwareVersionFilter);
        var softwareVersions = softwareVersionResponse.Data;

        if (softwareVersions is not null)
            return softwareVersions;

        return new List<SoftwareVersion>();
    }

    public async Task<IEnumerable<SoftwareSystem>> GetSoftwareSystemFromSoftwareVersionAsync(IEnumerable<SoftwareVersion> softwareVersions)
    {
        var softwareSystemIds = softwareVersions.Select(x => x.SoftwareSystemId.ToString()).ToList();
        var softwareSystemFilter = new FilterGenerator<SoftwareSystem>().GetFilterForPropertyByListOfIds("Id", softwareSystemIds);
        var softwareSystemResponse = await _managerService.SoftwareSystemManager().GetAsync(softwareSystemFilter);
        var softwareSystem = softwareSystemResponse.Data;

        if (softwareSystem is not null)
            return softwareSystem;

        return new List<SoftwareSystem>();
    }

    public async Task<IEnumerable<VersionsLoad>> GetVersionsLoadsByLoadIdAsync(int id)
    {
        var versionLoadsFilter = new FilterGenerator<VersionsLoad>().GetFilterWherePropertyEqualsValue("LoadId", id);
        var versionLoadresponse = await _managerService.VersionsLoadManager().GetAsync(versionLoadsFilter);
        var versionLoads = versionLoadresponse.Data;

        if (versionLoads is not null)
            return versionLoads;

        return new List<VersionsLoad>();
    }

    public async Task<IEnumerable<HardwareConfig>> GetHardwareConfigsFromSoftwareSystems(IEnumerable<SoftwareSystem> softwareSystems)
    {
        var hardwareConfigIds = softwareSystems.Select(i => i.HardwareConfigId.ToString()).ToList();
        var hardwareConfigFilter = new FilterGenerator<HardwareConfig>().GetFilterForPropertyByListOfIds("Id", hardwareConfigIds);
        var hardwareConfigresponse = await _managerService.HardwareConfigManager().GetAsync(hardwareConfigFilter);
        var hardwareConfig = hardwareConfigresponse.Data;

        if(hardwareConfig is not null)
            return hardwareConfig;

        return new List<HardwareConfig>();
    }

    public async Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsFromVersionsLoads(IEnumerable<VersionsLoad> versionsLoads)
    {
        var softwareVersionIds = versionsLoads.Select(i => i.SoftwareVersionId.ToString()).ToList();
        var softVersionFilter = new FilterGenerator<SoftwareVersion>().GetFilterWherePropertyEqualsValues("SoftwareVersion", softwareVersionIds);
        var softwareVersionResponse = await _managerService.SoftwareVersionManager().GetAsync(softVersionFilter);
        var softwareVersions = softwareVersionResponse.Data;

        if (softwareVersions is not null)
            return await Task.Run(() => softwareVersions);

        return new List<SoftwareVersion>();

    }
}

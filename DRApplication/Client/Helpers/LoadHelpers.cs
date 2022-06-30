using DRApplication.Client.Interfaces;
using DRApplication.Client.Services;
using DRApplication.Shared.Models;
namespace DRApplication.Client.Helpers;

public class LoadHelpers : ILoadHelpers
{
    private readonly ManagerService _managerService;

    public LoadHelpers(ManagerService managerService)
    {
        _managerService = managerService;
    }

    public async Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsFromVersionLoads(IEnumerable<VersionsLoad> versionsLoads)
    {
        var softwareVersionIds = versionsLoads.Select(x => x.SoftwareVersionId.ToString()).ToList();
        var softwareVersionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByListOfIdsAsync("Id", softwareVersionIds);
        var softwareVersionResponse = await _managerService.SoftwareVersionManager().GetAsync(softwareVersionFilter);
        var softwareVersions = softwareVersionResponse.Data;

        if (softwareVersions is not null)
            return softwareVersions;

        return new List<SoftwareVersion>();
    }

    public async Task<IEnumerable<SoftwareSystem>> GetSoftwareSystemFromSoftwareVersionAsync(IEnumerable<SoftwareVersion> softwareVersions)
    {
        var softwareSystemIds = softwareVersions.Select(x => x.SoftwareSystemId.ToString()).ToList();
        var softwareSystemFilter = await new FilterGenerator<SoftwareSystem>().GetFilterForPropertyByListOfIdsAsync("Id", softwareSystemIds);
        var softwareSystemResponse = await _managerService.SoftwareSystemManager().GetAsync(softwareSystemFilter);
        var softwareSystem = softwareSystemResponse.Data;

        if (softwareSystem is not null)
            return softwareSystem;

        return new List<SoftwareSystem>();
    }

    public async Task<IEnumerable<VersionsLoad>> GetVersionsLoadsByLoadIdAsync(int id)
    {
        var versionLoadsFilter = await new FilterGenerator<VersionsLoad>().GetFilterWherePropertyEqualsValueAsync("LoadId", id);
        var versionLoadresponse = await _managerService.VersionsLoadManager().GetAsync(versionLoadsFilter);
        var versionLoads = versionLoadresponse.Data;

        if (versionLoads is not null)
            return versionLoads;

        return new List<VersionsLoad>();
    }

    public async Task<IEnumerable<HardwareConfig>> GetHardwareConfigsFromSoftwareSystems(IEnumerable<SoftwareSystem> softwareSystems)
    {
        var hardwareConfigIds = softwareSystems.Select(i => i.HardwareConfigId.ToString()).ToList();
        var hardwareConfigFilter = await new FilterGenerator<HardwareConfig>().GetFilterForPropertyByListOfIdsAsync("Id", hardwareConfigIds);
        var hardwareConfigresponse = await _managerService.HardwareConfigManager().GetAsync(hardwareConfigFilter);
        var hardwareConfig = hardwareConfigresponse.Data;

        if(hardwareConfig is not null)
            return hardwareConfig;

        return new List<HardwareConfig>();
    }

    public async Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsFromVersionsLoads(IEnumerable<VersionsLoad> versionsLoads)
    {
        var softwareVersionIds = versionsLoads.Select(i => i.SoftwareVersionId.ToString()).ToList();
        var softVersionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterWherePropertyEqualsValuesAsync("SoftwareVersion", softwareVersionIds);
        var softwareVersionResponse = await _managerService.SoftwareVersionManager().GetAsync(softVersionFilter);
        var softwareVersions = softwareVersionResponse.Data;

        if (softwareVersions is not null)
            return await Task.Run(() => softwareVersions);

        return new List<SoftwareVersion>();

    }
}

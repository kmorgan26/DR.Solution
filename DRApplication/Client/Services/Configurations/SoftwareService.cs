using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services;

public class SoftwareService : ISoftwareService
{

    #region ---Fields and Constructor ---

    private readonly SoftwareSystemManager _softwareSystemManager;
    private readonly SoftwareVersionManager _softwareVersionManager;
    private readonly VersionsLoadManager _versionsLoadManager;

    public SoftwareService(SoftwareSystemManager softwareSystemManager, SoftwareVersionManager softwareVersionManager, VersionsLoadManager versionsLoadManager)
    {
        _softwareSystemManager = softwareSystemManager;
        _softwareVersionManager = softwareVersionManager;
        _versionsLoadManager = versionsLoadManager;
    }

    #endregion

    #region ---Single Object Methods---

    public async Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id)
    {
        var softwareSystem = await _softwareSystemManager.GetByIdAsync(id);
        if (softwareSystem == null)
            return new SoftwareSystemVm();

        return Mapping.Mapper.Map<SoftwareSystemVm>(softwareSystem);
    }

    #endregion

    #region Collection Methods---
    
    public async Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemVmsByHardwareConfigId(int id)
    {
        var filter = await new FilterGenerator<SoftwareSystem>().GetFilterForPropertyByNameAsync("HardwareConfigId", id);
        var softwareSystems = await _softwareSystemManager.GetAsync(filter);
        return Mapping.Mapper.Map<IEnumerable<SoftwareSystemVm>>(softwareSystems.Data);
    }
    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id)
    {
        var softwareSystemFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByNameAsync("SoftwareSystemId", id);
        var softwareVersionResponse = await _softwareVersionManager.GetAsync(softwareSystemFilter);

        if (softwareVersionResponse.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<SoftwareVersionVm>>(softwareVersionResponse.Data);

        return new List<SoftwareVersionVm>();
    }
    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsByLoadId(int id)
    {
        var versionLoadFilter = await new FilterGenerator<VersionsLoad>().GetFilterForPropertyByNameAsync("LoadId", id);
        var versionLoadResponse = await _versionsLoadManager.GetAsync(versionLoadFilter);

        List<string> softwareVersionIdList = new List<string>();
        
        foreach (var item in versionLoadResponse.Data)
        {
            softwareVersionIdList.Add(item.SoftwareVersionId.ToString());
        }
        var softVersionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertiesByNamesAsync("SoftwareVersion", softwareVersionIdList);
        var softwareVersionResponse = await _softwareVersionManager.GetAsync(softVersionFilter);

        return Mapping.Mapper.Map<IEnumerable<SoftwareVersionVm>>(softwareVersionResponse.Data);

    }

    #endregion

}

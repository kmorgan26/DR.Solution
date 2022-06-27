using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class SoftwareService : ISoftwareService
{

    #region ---Fields and Constructor ---

    private readonly ManagerService _managerService;

    public SoftwareService(ManagerService managerService)
    {
        _managerService = managerService;
    }

    #endregion

    #region ---Single Object Methods---

    public async Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id)
    {
        var softwareSystem = await _managerService.SoftwareSystemManager().GetByIdAsync(id);
        if (softwareSystem == null)
            return new SoftwareSystemVm();

        return Mapping.Mapper.Map<SoftwareSystemVm>(softwareSystem);
    }
    public async Task<SoftwareVersionVm> GetSoftwareVersionVmById(int id)
    {
        var softwareVersion = await _managerService.SoftwareVersionManager().GetByIdAsync(id);
        if (softwareVersion == null)
            return new SoftwareVersionVm();

        return new SoftwareVersionVm()
        {
            Id = id,
            Name = softwareVersion.Name,
            SoftwareSystemId = softwareVersion.SoftwareSystemId,
            VersionDate = softwareVersion.VersionDate,
            VersionDateString = softwareVersion.VersionDate.ToShortDateString()
        };

    }

    #endregion

    #region ---Collection Methods---

    public async Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemVmsByHardwareConfigId(int id)
    {
        var filter = await new FilterGenerator<SoftwareSystem>().GetFilterWherePropertyEqualsValueAsync("HardwareConfigId", id);
        var softwareSystems = await _managerService.SoftwareSystemManager().GetAsync(filter);
        return Mapping.Mapper.Map<IEnumerable<SoftwareSystemVm>>(softwareSystems.Data).OrderBy(i => i.Name);
    }
    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id)
    {
        var softwareSystemFilter = await new FilterGenerator<SoftwareVersion>().GetFilterWherePropertyEqualsValueAsync("SoftwareSystemId", id);
        var softwareVersionResponse = await _managerService.SoftwareVersionManager().GetAsync(softwareSystemFilter);

        if (softwareVersionResponse.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<SoftwareVersionVm>>(softwareVersionResponse.Data);

        return new List<SoftwareVersionVm>();
    }
    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsByLoadId(int id)
    {
        var versionLoadFilter = await new FilterGenerator<VersionsLoad>().GetFilterWherePropertyEqualsValueAsync("LoadId", id);
        var versionLoadResponse = await _managerService.VersionsLoadManager().GetAsync(versionLoadFilter);

        List<string> softwareVersionIdList = new List<string>();

        foreach (var item in versionLoadResponse.Data)
        {
            softwareVersionIdList.Add(item.SoftwareVersionId.ToString());
        }
        var softVersionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterWherePropertyEqualsValuesAsync("SoftwareVersion", softwareVersionIdList);
        var softwareVersionResponse = await _managerService.SoftwareVersionManager().GetAsync(softVersionFilter);

        return Mapping.Mapper.Map<IEnumerable<SoftwareVersionVm>>(softwareVersionResponse.Data);

    }
    public async Task<IEnumerable<VersionsLoad>> GetVersionLoadsByLoadId(int id)
    {
        var versionLoadsFilter = await new FilterGenerator<VersionsLoad>().GetFilterWherePropertyEqualsValueAsync("LoadId", id);
        var versionLoadresponse = await _managerService.VersionsLoadManager().GetAsync(versionLoadsFilter);
        if (versionLoadresponse.Data is not null)
        {
            return versionLoadresponse.Data;
        }
        return new List<VersionsLoad>();
    }
    public async Task<IEnumerable<SoftwareSystem>> GetSoftwareSystemsByIds(List<string> ids)
    {
        var systemFilter = await new FilterGenerator<SoftwareSystem>().GetFilterForPropertyByListOfIdsAsync("Id", ids);
        var systemResponse = await _managerService.SoftwareSystemManager().GetAsync(systemFilter);
        if (systemResponse.Data is not null)
            return systemResponse.Data;
        return new List<SoftwareSystem>();
    }
    public async Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsByIds(List<string> ids)
    {
        var versionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByListOfIdsAsync("Id", ids);
        var versionResponse = await _managerService.SoftwareVersionManager().GetAsync(versionFilter);
        if(versionResponse.Data is not null)
              return versionResponse.Data;
        return new List<SoftwareVersion>();
    }

    #endregion

}
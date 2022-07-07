using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class HardwareService : IHardwareService
{

    #region ---Fields and Constructor ---

    private readonly IManagerService _managerService;
    private readonly IMapperService _mapperService;

    public HardwareService(IManagerService managerService, IMapperService mapperService)
    {
        _managerService = managerService;
        _mapperService = mapperService;
    }

    #endregion

    #region ---Single Object Methods---

    public async Task<HardwareSystemVm> GetHardwareSystemVmById(int id)
    {
        var hardwareSystem = await _managerService.HardwareSystemManager().GetByIdAsync(id);
        if (hardwareSystem is not null)
            return _mapperService.HardwareSystemVmFromHardwareSystem(hardwareSystem);

        return new HardwareSystemVm();
    }
    public async Task<HardwareSystemEditVm> GetHardwareSystemEditVmById(int id)
    {
        var hardwareSystem = await _managerService.HardwareSystemManager().GetByIdAsync(id);
        if (hardwareSystem is not null)
            return _mapperService.HardwareSystemEditVmFromHardwareSystem(hardwareSystem);

        return new HardwareSystemEditVm();
    }
    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        var hardwareConfig = await _managerService.HardwareConfigManager().GetByIdAsync(id);
        if (hardwareConfig is not null)
            return _mapperService.HardwareConfigVmFromHardwareConfig(hardwareConfig);

        return new HardwareConfigVm();
    }
    public async Task<HardwareVersionVm> GetHardwareVersionVmById(int id)
    {
        var hardwareVersion = await _managerService.HardwareVersionManager().GetByIdAsync(id);
        if (hardwareVersion is not null)
            return _mapperService.HardwareVersionVmFromHardwareVersion(hardwareVersion);

        return new HardwareVersionVm();
    }

    #endregion

    #region ---Collection Methods---

    public async Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms()
    {
        var hardwareSystems = await _managerService.HardwareSystemManager().GetAllAsync();
        if(hardwareSystems is not null)
            return _mapperService.HardwareSystemVmsFromHardwareSystems(hardwareSystems);

        return new List<HardwareSystemVm>();
    }

    public async Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionVmsByHardwareSystemId(int id)
    {
        //Filter: FROM HardwareVersions WHERE HardwareSystemId = id
        var hardwareSystemFilter = await new FilterGenerator<HardwareVersion>().GetFilterWherePropertyEqualsValueAsync("HardwareSystemId", id);
        var hardwareVerionResponse = await _managerService.HardwareVersionManager().GetAsync(hardwareSystemFilter);
        var hardwareVersionVms = hardwareVerionResponse.Data;

        if (hardwareVersionVms is not null)
            return _mapperService.HardwareVersionVmsFromHardwareVersions(hardwareVersionVms);

        return new List<HardwareVersionVm>();
    }
    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int id)
    {
        //Filter: FROM HardwareConfigs WHERE DeviceTypeId = id
        var deviceTypeFilter = await new FilterGenerator<HardwareConfig>().GetFilterWherePropertyEqualsValueAsync("DeviceTypeId", id);
        var hardwareConfigResponse = await _managerService.HardwareConfigManager().GetAsync(deviceTypeFilter);
        var hardwareConfigs = hardwareConfigResponse.Data;

        if (hardwareConfigs is not null)
            return _mapperService.HardwareConfigVmsFromHardwareConfigs(hardwareConfigs);

        return new List<HardwareConfigVm>();
    }
    public async Task<bool> UpdateHardwareSystemFromHardwareSystemEditVm(HardwareSystemEditVm hardwareSystemEditVm)
    {
        var hardwareSystem = _mapperService.HardwareSystemFromHardwareSystemEditVm(hardwareSystemEditVm);

        try
        {
            var result = await _managerService.HardwareSystemManager().UpdateAsync(hardwareSystem);
            return result is not null;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> UpdateHardwareVersionFromHardwareVersionEditVmAsync(HardwareVersionEditVm hardwareVersionEditVm)
    {
        var hardwareVersion = _mapperService.HardwareVersionFromHardwareVersionEditVm(hardwareVersionEditVm);

        try
        {
            var result = await _managerService.HardwareVersionManager().UpdateAsync(hardwareVersion);
            return result is not null;
        }
        catch
        {
            return false;
        }
    }
    public async Task<int> InsertHardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm)
    {
        var hardwareSystem = _mapperService.HardwareSystemFromHardwareSystemInsertVm(hardwareSystemInsertVm);

        try
        {
            var result = await _managerService.HardwareSystemManager().InsertAsync(hardwareSystem);
            if (result.Id > 0)
                return result.Id;
            else
                return 0;
        }
        catch
        {
            return 0;
        }
    }

    #endregion

}
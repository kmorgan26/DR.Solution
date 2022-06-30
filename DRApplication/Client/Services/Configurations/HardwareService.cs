using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class HardwareService : IHardwareService
{

    #region ---Fields and Constructor ---
    private readonly ManagerService _managerService;
    private readonly IMapperService _mapperService;

    public HardwareService(ManagerService managerService, IMapperService mapperService)
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
            return await _mapperService.HardwareSystemVmFromHardwareSystemAsync(hardwareSystem);

        return new HardwareSystemVm();
    }
    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        var hardwareConfig = await _managerService.HardwareConfigManager().GetByIdAsync(id);
        if (hardwareConfig is not null)
            return await _mapperService.HardwareConfigVmFromHardwareConfigAsync(hardwareConfig);

        return new HardwareConfigVm();
    }

    #endregion

    #region ---Collection Methods---

    public async Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms()
    {
        var hardwareSystems = await _managerService.HardwareSystemManager().GetAllAsync();
        if(hardwareSystems is not null)
            return await _mapperService.HardwareSystemVmsFromHardwareSystemsAsync(hardwareSystems);

        return new List<HardwareSystemVm>();
    }
    public async Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionVmsByHardwareSystemId(int id)
    {
        //Filter: FROM HardwareVersions WHERE HardwareSystemId = id
        var hardwareSystemFilter = await new FilterGenerator<HardwareVersion>().GetFilterWherePropertyEqualsValueAsync("HardwareSystemId", id);
        var hardwareVerionResponse = await _managerService.HardwareVersionManager().GetAsync(hardwareSystemFilter);
        var hardwareVersionVms = hardwareVerionResponse.Data;

        if (hardwareVersionVms is not null)
            return await _mapperService.HardwareVersionVmsFromHardwareVersionsAsync(hardwareVersionVms);

        return new List<HardwareVersionVm>();
    }
    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int id)
    {
        //Filter: FROM HardwareConfigs WHERE DeviceTypeId = id
        var deviceTypeFilter = await new FilterGenerator<HardwareConfig>().GetFilterWherePropertyEqualsValueAsync("DeviceTypeId", id);
        var hardwareConfigResponse = await _managerService.HardwareConfigManager().GetAsync(deviceTypeFilter);
        var hardwareConfigs = hardwareConfigResponse.Data;

        if (hardwareConfigs is not null)
            return await _mapperService.HardwareConfigVmsFromHardwareConfigsAsync(hardwareConfigs);

        return new List<HardwareConfigVm>();
    }

    #endregion

}
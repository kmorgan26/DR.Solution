using AutoMapper;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class HardwareService : IHardwareService
{

    #region ---Fields and Constructor ---
    private readonly ManagerService _managerService;

    public HardwareService(ManagerService managerService)
    {
        _managerService = managerService;
    }
    #endregion

    #region ---Single Object Methods---

    public async Task<HardwareSystemVm> GetHardwareSystemVmById(int id)
    {
        var hardwareSystem = await _managerService.HardwareSystemManager().GetByIdAsync(id);
        return Mapping.Mapper.Map<HardwareSystemVm>(hardwareSystem);
    }
    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        var hardwareConfigVm = await _managerService.HardwareConfigManager().GetByIdAsync(id);
        if (hardwareConfigVm == null)
            return new HardwareConfigVm();

        return Mapping.Mapper.Map<HardwareConfigVm>(hardwareConfigVm);
    }

    #endregion

    #region ---Collection Methods---

    public async Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms()
    {
        var hardwareSystems = await _managerService.HardwareSystemManager().GetAllAsync();
        return Mapping.Mapper.Map<IEnumerable<HardwareSystemVm>>(hardwareSystems);
    }
    public async Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionVmsByHardwareSystemId(int id)
    {
        //Filter: FROM HardwareVersions WHERE HardwareSystemId = id
        var hardwareSystemFilter = await new FilterGenerator<HardwareVersion>().GetFilterWherePropertyEqualsValueAsync("HardwareSystemId", id);
        var hardwareVerionResponse = await _managerService.HardwareVersionManager().GetAsync(hardwareSystemFilter);

        if (hardwareVerionResponse.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<HardwareVersionVm>>(hardwareVerionResponse.Data);

        return new List<HardwareVersionVm>();
    }
    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int id)
    {
        //Filter: FROM HardwareConfigs WHERE DeviceTypeId = id
        var deviceTypeFilter = await new FilterGenerator<HardwareConfig>().GetFilterWherePropertyEqualsValueAsync("DeviceTypeId", id);
        var hardwareConfigResponse = await _managerService.HardwareConfigManager().GetAsync(deviceTypeFilter);

        if (hardwareConfigResponse.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<HardwareConfigVm>>(hardwareConfigResponse.Data);

        return new List<HardwareConfigVm>();
    }

    #endregion

}
using AutoMapper;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Services;

public class HardwareService : IHardwareService
{

    #region ---Fields and Constructor ---
    private readonly HardwareSystemManager _hardwareSystemManager;
    private readonly HardwareVersionManager _hardwareVersionManager;
    private readonly HardwareConfigManager _hardwareConfigManager;

    public HardwareService(HardwareSystemManager hardwareSystemManager, HardwareVersionManager hardwareVersionManager, HardwareConfigManager hardwareConfigManager)
    {
        _hardwareSystemManager = hardwareSystemManager;
        _hardwareVersionManager = hardwareVersionManager;
        _hardwareConfigManager = hardwareConfigManager;
    }
    #endregion

    #region ---Single Object Methods---

    public async Task<HardwareSystemVm> GetHardwareSystemVmById(int id)
    {
        var hardwareSystem = await _hardwareSystemManager.GetByIdAsync(id);
        return Mapping.Mapper.Map<HardwareSystemVm>(hardwareSystem);
    }
    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        var hardwareConfigVm = await _hardwareConfigManager.GetByIdAsync(id);
        if (hardwareConfigVm == null)
            return new HardwareConfigVm();

        return Mapping.Mapper.Map<HardwareConfigVm>(hardwareConfigVm);
    }

    #endregion

    #region ---Collection Methods---

    public async Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms()
    {
        var hardwareSystems = await _hardwareSystemManager.GetAllAsync();
        return Mapping.Mapper.Map<IEnumerable<HardwareSystemVm>>(hardwareSystems);
    }
    public async Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionVmsByHardwareSystemId(int id)
    {
        //Filter: FROM HardwareVersions WHERE HardwareSystemId = id
        var hardwareSystemFilter = await new FilterGenerator<HardwareVersion>().GetFilterForPropertyByNameAsync("HardwareSystemId", id);
        var hardwareVerionResponse = await _hardwareVersionManager.GetAsync(hardwareSystemFilter);

        if (hardwareVerionResponse.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<HardwareVersionVm>>(hardwareVerionResponse.Data);

        return new List<HardwareVersionVm>();
    }
    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int id)
    {
        //Filter: FROM HardwareConfigs WHERE DeviceTypeId = id
        var deviceTypeFilter = await new FilterGenerator<HardwareConfig>().GetFilterForPropertyByNameAsync("DeviceTypeId", id);
        var hardwareConfigResponse = await _hardwareConfigManager.GetAsync(deviceTypeFilter);

        if (hardwareConfigResponse.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<HardwareConfigVm>>(hardwareConfigResponse.Data);

        return new List<HardwareConfigVm>();
    }

    #endregion

}
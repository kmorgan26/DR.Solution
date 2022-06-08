using AutoMapper;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services;

public class HardwareService : IHardwareService
{
    private readonly HardwareSystemManager _hardwareSystemManager;
    private readonly HardwareVersionManager _hardwareVersionManager;
    private readonly HardwareConfigManager _hardwareConfigManager;

    public HardwareService(HardwareSystemManager hardwareSystemManager, HardwareVersionManager hardwareVersionManager, HardwareConfigManager hardwareConfigManager)
    {
        _hardwareSystemManager = hardwareSystemManager;
        _hardwareVersionManager = hardwareVersionManager;
        _hardwareConfigManager = hardwareConfigManager;
    }


    public async Task<HardwareSystemVm> GetHardwareSystemVmById(int id)
    {
        var hardwareSystem = await _hardwareSystemManager.GetByIdAsync(id);
        return Mapping.Mapper.Map<HardwareSystemVm>(hardwareSystem);
    }

    public async Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms()
    {
        var hardwareSystems = await _hardwareSystemManager.GetAllAsync();
        return Mapping.Mapper.Map<IEnumerable<HardwareSystemVm>>(hardwareSystems);
    }

    public async Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionsByHardwareSystemId(int id)
    {
        var hardwareSystemFilter = await new FilterGenerator<HardwareVersion>().GetFilterForPropertyByNameAsync("HardwareSystemId", id);
        var hardwareVerions = await _hardwareVersionManager.GetAsync(hardwareSystemFilter);
        return Mapping.Mapper.Map<IEnumerable<HardwareVersionVm>>(hardwareVerions.Data);
    }
    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigsByDeviceTypeId(int id)
    {
        var deviceTypeFilter = await new FilterGenerator<HardwareConfig>().GetFilterForPropertyByNameAsync("DeviceTypeId", id);
        var hardwareConfigs = await _hardwareConfigManager.GetAsync(deviceTypeFilter);
        return Mapping.Mapper.Map<IEnumerable<HardwareConfigVm>>(hardwareConfigs.Data);
    }

    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        var hardwareConfigVm = await _hardwareConfigManager.GetByIdAsync(id);
        return Mapping.Mapper.Map<HardwareConfigVm>(hardwareConfigVm);
    }
}

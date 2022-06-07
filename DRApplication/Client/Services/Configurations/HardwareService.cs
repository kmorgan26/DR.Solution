using AutoMapper;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services;

public class HardwareService : IHardwareService
{
    private readonly HardwareSystemManager _hardwareSystemManager;
    private readonly HardwareVersionManager _hardwareVersionManager;

    public HardwareService(HardwareSystemManager hardwareSystemManager, HardwareVersionManager hardwareVersionManager)
    {
        _hardwareSystemManager = hardwareSystemManager;
        _hardwareVersionManager = hardwareVersionManager;
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
}

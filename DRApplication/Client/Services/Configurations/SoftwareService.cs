using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;
using AutoMapper;

namespace DRApplication.Client.Services;

public class SoftwareService : ISoftwareService
{
    private readonly SoftwareSystemManager _softwareSystemManager;
    private readonly SoftwareVersionManager _softwareVersionManager;

    public SoftwareService(SoftwareSystemManager softwareSystemManager, SoftwareVersionManager softwareVersionManager)
    {
        _softwareSystemManager = softwareSystemManager;
        _softwareVersionManager = softwareVersionManager;
    }

    public async Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemsByHardwareConfigId(int id)
    {
        var filter = await new FilterGenerator<SoftwareSystem>().GetFilterForPropertyByNameAsync("HardwareConfigId", id);
        var softwareSystems = await _softwareSystemManager.GetAsync(filter);
        return Mapping.Mapper.Map<IEnumerable<SoftwareSystemVm>>(softwareSystems.Data);
    }

    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionsBySoftwareSystemId(int id)
    {
        var softwareSystemFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByNameAsync("SoftwareSystemId", id);
        var softwareVersions = await _softwareVersionManager.GetAsync(softwareSystemFilter);
        return Mapping.Mapper.Map<IEnumerable<SoftwareVersionVm>>(softwareVersions.Data);
    }

    public async Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id)
    {
        var softwareSystemVm = await _softwareSystemManager.GetByIdAsync(id);
        return Mapping.Mapper.Map<SoftwareSystemVm>(softwareSystemVm);
    }
}

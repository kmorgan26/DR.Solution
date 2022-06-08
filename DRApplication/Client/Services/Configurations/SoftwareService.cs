using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;
using AutoMapper;

namespace DRApplication.Client.Services;

public class SoftwareService : ISoftwareService
{
    private readonly SoftwareSystemManager _softwareSystemManager;

    public SoftwareService(SoftwareSystemManager softwareSystemManager)
    {
        _softwareSystemManager = softwareSystemManager;
    }
    public async Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemsByHardwareConfigId(int id)
    {
        var systems = await _softwareSystemManager.GetAllAsync();
        var filterd = systems.Where(x => x.HardwareConfigId == id);
        return Mapping.Mapper.Map<IEnumerable<SoftwareSystemVm>>(filterd);
    }
}

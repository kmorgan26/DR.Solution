using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Services;

public class LoadBuilderService : ILoadBuilderService
{
    private readonly HardwareConfigManager _hardwareConfigManager;
    private readonly SoftwareSystemManager _softwareSystemManager;

    public LoadBuilderService(HardwareConfigManager hardwareConfigManager, SoftwareSystemManager softwareSystemManager)
    {
        _hardwareConfigManager = hardwareConfigManager;
        _softwareSystemManager = softwareSystemManager;
    }

    //TODO: Use a filter to get ONLY by DeviceTypeId
    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigsByDeviceTypeIdAsync(int i)
    {
        var configs = await _hardwareConfigManager.GetAllAsync();
        var filtered = configs.Where(x => x.DeviceTypeId == i);
        return Mapping.Mapper.Map<IEnumerable<HardwareConfigVm>>(filtered);
    }

    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        var config = await _hardwareConfigManager.GetByIdAsync(id);
        if(config == null)
            return new HardwareConfigVm();

        return Mapping.Mapper.Map<HardwareConfigVm>(config);
    }

    public async Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemsByHardwareConfigIg(int id)
    {
        var systems = await _softwareSystemManager.GetAllAsync();
        var filterd = systems.Where(x => x.HardwareConfigId == id);
        return Mapping.Mapper.Map<IEnumerable<SoftwareSystemVm>>(filterd);
    }
}

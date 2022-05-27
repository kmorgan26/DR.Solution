using DRApplication.Client.Enums;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Services;

public class PlatformService : IPlatformService
{
    private readonly MaintainerManager _maintainerManager;
    private readonly DeviceTypeManager _deviceTypeManager;
    private readonly DeviceManager _deviceManager;

    public PlatformService(MaintainerManager maintainerManager, DeviceTypeManager deviceTypeManager, DeviceManager deviceManager)
    {
        _maintainerManager = maintainerManager;
        _deviceTypeManager = deviceTypeManager;
        _deviceManager = deviceManager;
    }
    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsAsync()
    {
        var devices = await _deviceManager.GetAllAsync();
        var deviceTypes = await _deviceTypeManager.GetAllAsync();

        return devices.Select(dt => new DeviceVm
        {
            Id = dt.Id,
            Device = dt.Name,
            IsActive = dt.IsActive,
            Platform = deviceTypes
                    .Where(m => m.Id == dt.DeviceTypeId).FirstOrDefault().Name
        });
    }

    public async Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync()
    {
        var deviceTypes = await _deviceTypeManager.GetAllAsync();
        var maintainers = await _maintainerManager.GetAllAsync();

        var vms = deviceTypes.Select(dt => new DeviceTypeVm
        {
            Id = dt.Id,
            Platform = dt.Name,
            IsActive = dt.IsActive,
            MaintainerId = dt.MaintainerId,
            Maintainer = maintainers
                    .Where(m => m.Id == dt.MaintainerId).FirstOrDefault().Name
        });

        return vms;
    }

    public async Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync()
    {
        var maintainers = await _maintainerManager.GetAllAsync();

        var vms = maintainers.Select(m => new MaintainerVm
        {
             Id = m.Id,
             Maintainer = m.Name,
        });
        
        return vms;
    }

    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceListAsync(IEnumerable<Device> devices)
    {
        var deviceTypes = await _deviceTypeManager.GetAllAsync();
        
        var vms = devices.Select(m => new DeviceVm
        {
            Id = m.Id,
            Device = m.Name,
            DeviceTypeId = m.DeviceTypeId,
            Platform = deviceTypes.Where(a => a.Id == m.DeviceTypeId).FirstOrDefault().Name,
            IsActive = m.IsActive
        });

        return vms;
    }

}

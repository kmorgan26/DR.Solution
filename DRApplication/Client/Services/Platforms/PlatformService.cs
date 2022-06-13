using DRApplication.Shared.Enums;
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

    public async Task<DeviceTypeVm> GetDeviceTypeVmFromGenericVm(GenericListVm genericListVm)
    {
        var deviceType = await _deviceTypeManager.GetByIdAsync(genericListVm.Id);

        var vm = new DeviceTypeVm()
        {
            Id = deviceType.Id,
            IsActive = deviceType.IsActive,
            MaintainerId = deviceType.MaintainerId,
            Platform = deviceType.Name,
        };
        return vm;
    }

    public async Task<DeviceTypeVm> GetDeviceTypeVmById(int id)
    {
        var deviceType = await _deviceTypeManager.GetByIdAsync(id);
        var vm = new DeviceTypeVm()
        {
            Id = deviceType.Id,
            IsActive = deviceType.IsActive,
            MaintainerId = deviceType.MaintainerId,
            Platform = deviceType.Name,
        };
        return vm;
    }

    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDevicTypeId(int id)
    {
        //Filter = FROM Devices WHERE DeviceTypeId = id 
        var deviceTypeFilter = await new FilterGenerator<Device>().GetFilterForPropertyByNameAsync("DeviceTypeId", id);
        var devices = await _deviceManager.GetAsync(deviceTypeFilter);

        return Mapping.Mapper.Map<IEnumerable<DeviceVm>>(devices.Data);
    }
}

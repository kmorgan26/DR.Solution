using DRApplication.Shared.Enums;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Services;

public class PlatformService : IPlatformService
{

    #region --fields and constructor----

    private readonly MaintainerManager _maintainerManager;
    private readonly DeviceTypeManager _deviceTypeManager;
    private readonly DeviceManager _deviceManager;

    public PlatformService(MaintainerManager maintainerManager, DeviceTypeManager deviceTypeManager, DeviceManager deviceManager)
    {
        _maintainerManager = maintainerManager;
        _deviceTypeManager = deviceTypeManager;
        _deviceManager = deviceManager;
    }
    #endregion

    #region ---collections---

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
        }).OrderBy(i => i.Platform);

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
        }).OrderBy(i => i.Device); ;

        return vms;
    }
    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceTypeId(int id)
    {
        //Filter = FROM Devices WHERE DeviceTypeId = id 
        var deviceTypeFilter = await new FilterGenerator<Device>().GetFilterForPropertyByNameAsync("DeviceTypeId", id);
        var devices = await _deviceManager.GetAsync(deviceTypeFilter);

        return Mapping.Mapper.Map<IEnumerable<DeviceVm>>(devices.Data).OrderBy(i => i.Device);
    }
    public async Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsByMaintainerId(int id)
    {
        //Filter = FROM DeviceTypes WHERE MaintainerId = id 
        var maintainerFilter = await new FilterGenerator<DeviceType>().GetFilterForPropertyByNameAsync("MaintainerId", id);
        var deviceTypes = await _deviceTypeManager.GetAsync(maintainerFilter);
        var maintainers = await _maintainerManager.GetAllAsync();

        var result = deviceTypes.Data.Select(i => new DeviceTypeVm()
        {
            Id = i.Id,
            IsActive = i.IsActive,
            MaintainerId = i.MaintainerId,
            Platform = i.Name,
            Maintainer = maintainers.Where(m => m.Id == i.MaintainerId).FirstOrDefault().Name
        }).OrderBy(i => i.Platform); ;

        return result;
    }

    #endregion

    #region ---Object Methods---

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
    public async Task<MaintainerVm> GetMaintainerVmById(int id)
    {
        var maintainer = await _maintainerManager.GetByIdAsync(id);
        var maintainerVm = new MaintainerVm()
        {
            Id = maintainer.Id,
            Maintainer = maintainer.Name
        };
        return maintainerVm;
    }
    public async Task<DeviceType> GetDeviceTypeFromDeviceTypeVm(DeviceTypeVm deviceTypeVm)
    {
        var deviceType = new DeviceType()
        {
            Id = deviceTypeVm.Id,
            IsActive = deviceTypeVm.IsActive,
            MaintainerId = deviceTypeVm.MaintainerId,
            Name = deviceTypeVm.Platform
        };
        return await Task.Run(() => deviceType);
    }
    public async Task<Device> GetDeviceFromDeviceVm(DeviceVm deviceVm)
    {
        var device = new Device()
        {
            Id = deviceVm.Id,
            IsActive = deviceVm.IsActive,
            DeviceTypeId = deviceVm.DeviceTypeId,
            Name = deviceVm.Device
        };
        return await Task.Run(() => device);
    }
    public async Task<int> InsertDeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm)
    {
        var deviceType = new DeviceType()
        {
            IsActive = deviceTypeInsertVm.IsActive,
            MaintainerId = deviceTypeInsertVm.MaintainerId,
            Name = deviceTypeInsertVm.Name
        };
        try
        {
            var result = await _deviceTypeManager.InsertAsync(deviceType);
            if(result.Id > 0)
               return result.Id;
            else
               return 0;
        }
        catch
        {
            return 0;
        }
    }
    public async Task<bool> EditMaintainerFromMaintainerVm(MaintainerVm maintainerVm)
    {
        var maintainer = new Maintainer()
        {
            Id = maintainerVm.Id,
            Name = maintainerVm.Maintainer
        };
        try
        {
            var result = await _maintainerManager.UpdateAsync(maintainer);
            if (result != null)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }

    #endregion

}
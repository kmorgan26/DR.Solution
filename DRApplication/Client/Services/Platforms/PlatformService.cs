using DRApplication.Shared.Enums;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
using DRApplication.Client.Helpers;

namespace DRApplication.Client.Services;

public class PlatformService : IPlatformService
{

    #region --fields and constructor----

    private readonly ManagerService _managerService;
    private readonly IMapperService _mapperService;

    public PlatformService(ManagerService managerService, IMapperService mapperService)
    {
        _managerService = managerService;
        _mapperService = mapperService;
    }

    #endregion

    #region ---collections---

    public async Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync()
    {
        var deviceTypes = await _managerService.DeviceTypeManager().GetAllAsync();
        var maintainers = await _managerService.MaintainerManager().GetAllAsync();

        var deviceTypeVms = deviceTypes.Select(dt => new DeviceTypeVm
        {
            Id = dt.Id,
            Platform = dt.Name,
            IsActive = dt.IsActive,
            MaintainerId = dt.MaintainerId,
            Maintainer = maintainers
                    .Where(m => m.Id == dt.MaintainerId)
                    .FirstOrDefault().Name
        }).OrderBy(i => i.Platform);

        return deviceTypeVms;
    }
    public async Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync()
    {
        var maintainers = await _managerService.MaintainerManager().GetAllAsync();
        return await _mapperService.MaintainerVmsFromMaintainersAsync(maintainers);
    }
    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceTypeId(int id)
    {
        //Filter = FROM Devices WHERE DeviceTypeId = id 
        var deviceTypeFilter = await new FilterGenerator<Device>().GetFilterWherePropertyEqualsValueAsync("DeviceTypeId", id);
        var deviceResponse = await _managerService.DeviceManager().GetAsync(deviceTypeFilter);
        var devices = deviceResponse.Data?.OrderBy(i => i.Name);

        if (devices is not null)
            return await _mapperService.DeviceVmsFromDevicesAsync(devices);

        return new List<DeviceVm>();
    }
    public async Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsByMaintainerId(int id)
    {
        //Filter = FROM DeviceTypes WHERE MaintainerId = id 
        var maintainerFilter = await new FilterGenerator<DeviceType>().GetFilterWherePropertyEqualsValueAsync("MaintainerId", id);
        var deviceTypeResponse = await _managerService.DeviceTypeManager().GetAsync(maintainerFilter);
        var deviceTypes = deviceTypeResponse.Data;

        if (deviceTypes is not null)
            return await _mapperService.DeviceTypeVmsFromDeviceTypesAsync(deviceTypes);

        return new List<DeviceTypeVm>();
    }
    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsByListOfIds(List<string> ids)
    {
        var deviceFilter = await new FilterGenerator<Device>().GetFilterForPropertyByListOfIdsAsync("Id", ids);
        var deviceResponse = await _managerService.DeviceManager().GetAsync(deviceFilter);
        var devices = deviceResponse.Data;

        if (devices is not null)
            return await _mapperService.DeviceVmsFromDevicesAsync(devices);

        return new List<DeviceVm>();
    }

    #endregion

    #region ---Object Methods---

    public async Task<DeviceVm> GetDeviceVmById(int id)
    {
        var device = await _managerService.DeviceManager().GetByIdAsync(id);
        return await _mapperService.DeviceVmFromDeviceAsync(device);
    }
    public async Task<DeviceTypeVm> GetDeviceTypeVmById(int id)
    {
        var deviceType = await _managerService.DeviceTypeManager().GetByIdAsync(id);
        return await _mapperService.DeviceTypeVmFromDeviceTypeAsync(deviceType);
    }
    public async Task<DeviceTypeEditVm> GetDeviceTypeEditVmByIdAsync(int id)
    {
        var deviceType = await _managerService.DeviceTypeManager().GetByIdAsync(id);
        return await _mapperService.DeviceTypeEditVmFromDeviceTypeAsync(deviceType);
    }
    public async Task<MaintainerVm> GetMaintainerVmById(int id)
    {
        var maintainer = await _managerService.MaintainerManager().GetByIdAsync(id);
        return await _mapperService.MaintainerVmFromMaintainerAsync(maintainer);
    }
    public async Task<MaintainerEditVm> GetMaintainerEditVmById(int id)
    {
        var maintainer = await _managerService.MaintainerManager().GetByIdAsync(id);
        return await _mapperService.MaintainerEditVmFromMaintainerAsync(maintainer);
    }
    public async Task<int> InsertDeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm)
    {
        var deviceType = await _mapperService.DeviceTypeFromDeviceTypeInsertVmAsync(deviceTypeInsertVm);

        try
        {
            var result = await _managerService.DeviceTypeManager().InsertAsync(deviceType);
            if (result.Id > 0)
                return result.Id;
            else
                return 0;
        }
        catch
        {
            return 0;
        }
    }
    public async Task<bool> UpdateMaintainerFromMaintainerEditVm(MaintainerEditVm maintainerEditVm)
    {
        var maintainer = await _mapperService.MaintainerFromMaintainerEditVmAsync(maintainerEditVm);
        
        try
        {
            var result = await _managerService.MaintainerManager().UpdateAsync(maintainer);
            if (result != null)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }



    #endregion

}
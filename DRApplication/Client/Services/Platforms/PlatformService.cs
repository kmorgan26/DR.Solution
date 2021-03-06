using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
using DRApplication.Shared.Requests;

namespace DRApplication.Client.Services;

public class PlatformService : IPlatformService
{

    #region --fields and constructor----

    private readonly IManagerService _managerService;
    private readonly IMapperService _mapperService;
    private readonly AppState _appState;

    public PlatformService(IManagerService managerService, IMapperService mapperService, AppState appState)
    {
        _managerService = managerService;
        _mapperService = mapperService;
        _appState = appState;
    }

    #endregion

    #region ---collections---

    public async Task<IEnumerable<DeviceTypeVm>> GetAdHockDeviceTypeVmsAsync()
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT d.Id, d.Name[Platform], m.Name[Maintainer], d.IsActive " +
                        $"FROM DeviceTypes d " +
                        $"INNER JOIN Maintainers m ON m.Id = d.MaintainerId " +
                        $"WHERE d.MaintainerId = @maintainerId",
            Parameters = new Dictionary<string, int> { { "MaintainerId", _appState.MaintainerVm.Id } }
        };
        return await _managerService.DeviceTypeVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<DeviceVm>> GetAdHockDeviceVmByDeviceTypeIdAsync(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT d.Id, d.Name[Device], dt.Name[Platform], d.IsActive " +
                $"FROM Devices d " +
                $"INNER JOIN DeviceTypes dt ON dt.Id = d.DeviceTypeId " +
                $"WHERE d.DeviceTypeId = @deviceTypeId",
            Parameters = new Dictionary<string, int> { { "DeviceTypeId", _appState.DeviceTypeVm.Id } }
        };
        return await _managerService.DeviceVmManager().Get(adhocRequest);
    }
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
        return _mapperService.MaintainerVmsFromMaintainers(maintainers);
    }
    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceTypeId(int id)
    {
        //Filter = FROM Devices WHERE DeviceTypeId = id 
        var deviceTypeFilter = new FilterGenerator<Device>().GetFilterWherePropertyEqualsValue("DeviceTypeId", id);
        var deviceResponse = await _managerService.DeviceManager().GetAsync(deviceTypeFilter);
        var devices = deviceResponse.Data?.OrderBy(i => i.Name);

        if (devices is not null)
            return await _mapperService.DeviceVmsFromDevicesAsync(devices);

        return new List<DeviceVm>();
    }
    public async Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsByMaintainerId(int id)
    {
        //Filter = FROM DeviceTypes WHERE MaintainerId = id 
        var maintainerFilter = new FilterGenerator<DeviceType>().GetFilterWherePropertyEqualsValue("MaintainerId", id);
        var deviceTypeResponse = await _managerService.DeviceTypeManager().GetAsync(maintainerFilter);
        var deviceTypes = deviceTypeResponse.Data;

        if (deviceTypes is not null)
            return await _mapperService.DeviceTypeVmsFromDeviceTypesAsync(deviceTypes);

        return new List<DeviceTypeVm>();
    }
    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsByListOfIds(List<string> ids)
    {
        var deviceFilter = new FilterGenerator<Device>().GetFilterForPropertyByListOfIds("Id", ids);
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
    public async Task<DeviceEditVm> GetDeviceEditVmByIdAsync(int id)
    {
        var device = await _managerService.DeviceManager().GetByIdAsync(id);
        return _mapperService.DeviceEditVmFromDevice(device);
    }
    public async Task<DeviceTypeVm> GetDeviceTypeVmByIdAsync(int id)
    {
        var deviceType = await _managerService.DeviceTypeManager().GetByIdAsync(id);
        return await _mapperService.DeviceTypeVmFromDeviceTypeAsync(deviceType);
    }
    public async Task<DeviceTypeEditVm> GetDeviceTypeEditVmByIdAsync(int id)
    {
        var deviceType = await _managerService.DeviceTypeManager().GetByIdAsync(id);
        return _mapperService.DeviceTypeEditVmFromDeviceType(deviceType);
    }
    public async Task<MaintainerVm> GetMaintainerVmById(int id)
    {
        var maintainer = await _managerService.MaintainerManager().GetByIdAsync(id);
        return _mapperService.MaintainerVmFromMaintainer(maintainer);
    }
    public async Task<MaintainerEditVm> GetMaintainerEditVmById(int id)
    {
        var maintainer = await _managerService.MaintainerManager().GetByIdAsync(id);
        return _mapperService.MaintainerEditVmFromMaintainer(maintainer);
    }
    public async Task<int> InsertDeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm)
    {
        var deviceType = _mapperService.DeviceTypeFromDeviceTypeInsertVm(deviceTypeInsertVm);

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
    public async Task<int> InsertDeviceFromDeviceInsertVm(DeviceInsertVm deviceTypeInsertVm)
    {
        var device = _mapperService.DeviceFromDeviceInsertVm(deviceTypeInsertVm);

        try
        {
            var result = await _managerService.DeviceManager().InsertAsync(device);
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
        var maintainer = _mapperService.MaintainerFromMaintainerEditVm(maintainerEditVm);

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
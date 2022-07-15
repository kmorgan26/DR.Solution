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

    public async Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync()
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT d.Id, d.Name[Platform], m.Name[Maintainer], d.IsActive " +
                        $"FROM DeviceTypes d " +
                        $"INNER JOIN Maintainers m ON m.Id = d.MaintainerId ",
            Parameters = null
        };
        return await _managerService.DeviceTypeVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsByMaintainerIdAsync(int id)
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
    public async Task<IEnumerable<DeviceVm>> GetDeviceVmByDeviceTypeIdAsync(int id)
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
    public async Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync()
    {
        var maintainers = await _managerService.MaintainerManager().GetAllAsync();
        return _mapperService.MaintainerVmsFromMaintainers(maintainers);
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
    public async Task<IEnumerable<DeviceVm>> GetDeviceVmsByLoadId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT d.Id, d.Name[Device], d.DeviceTypeId, d.IsActive, dt.Name[Platform] " +
                $"FROM Devices d " +
                $"INNER JOIN DeviceTypes dt ON dt.Id = d.DeviceTypeId " +
                $"INNER JOIN CurrentLoads cl ON cl.DeviceId = d.Id " +
                $"INNER JOIN Loads l ON l.Id = cl.LoadId " +
                $"WHERE l.Id = @loadId",
            Parameters = new Dictionary<string, int> { { "loadId", id } }
        };
        return await _managerService.DeviceVmManager().Get(adhocRequest);
    }

    #endregion

    #region ---Object Methods---

    public async Task<DeviceVm> GetDeviceVmByIdAsync(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT d.Id, d.Name[Device], d.DeviceTypeId, d.IsActive, v.Name[Platform] " +
                $"FROM Devices d " +
                $"INNER JOIN DeviceTypes v ON v.Id = d.DeviceTypeId " +
                $"WHERE d.Id = @deviceId",
            Parameters = new Dictionary<string, int> { { "deviceId", id } }
        };
        return await _managerService.DeviceVmManager().GetByIdAsync(id, adhocRequest);
    }
    public async Task<DeviceTypeVm> GetDeviceTypeVmByIdAsync(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT d.Id, d.Name[Platform], d.MaintainerId, d.IsActive, m.Name[Maintainer] " +
                $"FROM DeviceTypes d " +
                $"INNER JOIN Maintainers m ON m.Id = d.MaintainerId " +
                $"WHERE d.Id = @deviceTypeId",
            Parameters = new Dictionary<string, int> { { "deviceTypeId", id } }
        };
        return await _managerService.DeviceTypeVmManager().GetByIdAsync(id, adhocRequest);
    }
    public async Task<MaintainerVm> GetMaintainerVmById(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT m.Id, m.Name[Maintainer] " +
                $"FROM Maintainers m " +
                $"WHERE m.Id = @maintainerId",
            Parameters = new Dictionary<string, int> { { "maintainerId", id } }
        };
        return await _managerService.MaintainerVmManager().GetByIdAsync(id, adhocRequest);
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
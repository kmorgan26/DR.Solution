using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
using DRApplication.Shared.Requests;

namespace DRApplication.Client.Services;

public class HardwareService : IHardwareService
{

    #region ---Fields and Constructor ---

    private readonly IManagerService _managerService;
    private readonly IMapperService _mapperService;

    public HardwareService(IManagerService managerService, IMapperService mapperService)
    {
        _managerService = managerService;
        _mapperService = mapperService;
    }

    #endregion

    #region ---Single Object Methods---
    public async Task<HardwareSystemVm> GetHardwareSystemVmById(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT h.Id, h.Name " +
                        $"FROM HardwareSystems h " +
                        $"WHERE h.Id = @hardwareSystemId ",
            Parameters = new Dictionary<string, int> { { "hardwareSystemId", id } }
        };
        return await _managerService.HardwareSystemVmManager().GetByIdAsync(id, adhocRequest);
    }
    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT h.Id, h.Name, h.DeviceTypeId " +
                        $"FROM HardwareConfigs h " +
                        $"WHERE h.Id = @hardwareConfigId ",
            Parameters = new Dictionary<string, int> { { "hardwareConfigId", id } }
        };
        return await _managerService.HardwareConfigVmManager().GetByIdAsync(id, adhocRequest);
    }
    public async Task<HardwareVersionVm> GetHardwareVersionVmById(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT h.Id, h.Name, h.HardwareSystemId, h.VersionDate " +
                        $"FROM HardwareVersions h " +
                        $"WHERE h.Id = @hardwareVersionId ",
            Parameters = new Dictionary<string, int> { { "hardwareVersionId", id } }
        };
        return await _managerService.HardwareVersionVmManager().GetByIdAsync(id, adhocRequest);
    }

    #endregion

    #region ---Collection Methods---

    public async Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms()
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT h.Id, h.Name " +
                        $"FROM HardwareSystems h ",
            Parameters = null
        };
        return await _managerService.HardwareSystemVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionVmsByHardwareSystemId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT h.Id, h.Name, h.HardwareSystemId, h.VersionDate " +
                        $"FROM HardwareVersions h " +
                        $"WHERE h.HardwareSystemId = @hardwareSystemId " ,
            Parameters = new Dictionary<string, int> { { "hardwareSystemId", id } }
        };
        return await _managerService.HardwareVersionVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT h.Id, h.Name, h.DeviceTypeId " +
                        $"FROM HardwareConfigs h " +
                        $"WHERE h.DeviceTypeId = @deviceTypeId ",
            Parameters = new Dictionary<string, int> { { "deviceTypeId", id } }
        };
        return await _managerService.HardwareConfigVmManager().Get(adhocRequest);
    }

    #endregion

}
﻿using DRApplication.Client.Interfaces;
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
        var hardwareSystems = await _managerService.HardwareSystemManager().GetAllAsync();
        if(hardwareSystems is not null)
            return _mapperService.HardwareSystemVmsFromHardwareSystems(hardwareSystems);

        return new List<HardwareSystemVm>();
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
        //Filter: FROM HardwareConfigs WHERE DeviceTypeId = id
        var deviceTypeFilter = new FilterGenerator<HardwareConfig>().GetFilterWherePropertyEqualsValue("DeviceTypeId", id);
        var hardwareConfigResponse = await _managerService.HardwareConfigManager().GetAsync(deviceTypeFilter);
        var hardwareConfigs = hardwareConfigResponse.Data;

        if (hardwareConfigs is not null)
            return _mapperService.HardwareConfigVmsFromHardwareConfigs(hardwareConfigs);

        return new List<HardwareConfigVm>();
    }
    public async Task<int> InsertHardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm)
    {
        var hardwareSystem = _mapperService.HardwareSystemFromHardwareSystemInsertVm(hardwareSystemInsertVm);

        try
        {
            var result = await _managerService.HardwareSystemManager().InsertAsync(hardwareSystem);
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

    #endregion

}
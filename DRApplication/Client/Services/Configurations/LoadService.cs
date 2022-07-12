using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Models;
using DRApplication.Client.Helpers;
using DRApplication.Shared.Requests;

namespace DRApplication.Client.Services;

public class LoadService : ILoadService
{

    #region ---Fields and Constructor ---

    private readonly IPlatformService _platformService;
    private readonly ISoftwareService _softwareService;
    private readonly IManagerService _managerService;
    private readonly AppState _appState;

    private readonly ILoadHelpers _loadHelpers;
    private readonly IMapperService _mapperService;

    public LoadService(
            IPlatformService platformService,
            ISoftwareService softwareService,
            IManagerService managerService,
            AppState appState,
            ILoadHelpers loadHelpers,
            IMapperService mapperService
        )
    {
        _platformService = platformService;
        _softwareService = softwareService;
        _managerService = managerService;
        _appState = appState;
        _loadHelpers = loadHelpers;
        _mapperService = mapperService;
    }

    #endregion

    #region ---Collection Object Methods---
    public async Task<IEnumerable<CurrentLoadVm>> GetCurrentLoadVmsByLoadId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT cl.Id, cl.LoadId, cl.DeviceId, l.Name[LoadName], d.Name[Device] " +
                $"FROM CurrentLoads cl " +
                $"INNER JOIN Devices d ON d.Id = cl.DeviceId " +
                $"INNER JOIN Loads l ON l.Id = cl.LoadId " +
                $"WHERE cl.LoadId = @LoadId",
            Parameters = new Dictionary<string, int> { { "LoadId", _appState.LoadVm.Id } }
        };
        return await _managerService.CurrentLoadVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<CurrentLoadVm>> GetCurrentLoadVmsByDeviceTypeId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT cl.Id, cl.LoadId, cl.DeviceId, l.Name[LoadName], d.Name[Device] " + 
                $"FROM CurrentLoads cl " + 
                $"INNER JOIN Devices d ON d.Id = cl.DeviceId " + 
                $"INNER JOIN Loads l ON l.Id = cl.LoadId " + 
                $"INNER JOIN HardwareConfigs h ON h.Id = l.HardwareConfigId " +
                $"WHERE h.DeviceTypeId = @DeviceTypeId",
            Parameters = new Dictionary<string, int> { { "DeviceTypeId", _appState.DeviceTypeVm.Id } }
        };
        return await _managerService.CurrentLoadVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<LoadVm>> GetLoadVmsByHardwareConfigId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT l.Id, l.Name, l.HardwareConfigId, l.IsAccepted " +
                $"FROM Loads l " +
                $"WHERE l.HardwareConfigId = @HardwareConfigId",
            Parameters = new Dictionary<string, int> { { "HardwareConfigId", id } }
        };
        return await _managerService.LoadVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT v.Id, v.LoadId, v.SoftwareVersionId, sv.Name[SoftwareVersionName], ss.Name[SoftwareSystemName] " +
                $"FROM VersionsLoads v " +
                $"INNER JOIN SoftwareVersions sv ON sv.Id = v.SoftwareVersionId " +
                $"INNER JOIN SoftwareSystems ss ON ss.Id = sv.SoftwareSystemId " +
                $"WHERE v.LoadId = @LoadId",
            Parameters = new Dictionary<string, int> { { "LoadId", id } }
        };
        return await _managerService.VersionsLoadVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<SpecificLoadVm>> GetSpecificLoadVmsByDeviceTypeId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT sl.Id, sl.LoadId, sl.DeviceId, l.Name[LoadName], d.Name[Device] " +
                $"FROM SpecificLoads sl " +
                $"INNER JOIN Devices d ON d.Id = sl.DeviceId " +
                $"INNER JOIN Loads l ON l.Id = sl.LoadId " +
                $"INNER JOIN HardwareConfigs h ON h.Id = l.HardwareConfigId " +
                $"WHERE h.DeviceTypeId = @DeviceTypeId",
            Parameters = new Dictionary<string, int> { { "DeviceTypeId", _appState.DeviceTypeVm.Id } }
        };
        return await _managerService.SpecificLoadVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<SpecificLoadVm>> MapSpecificLoadsToSpecificLoadVms(IEnumerable<SpecificLoad> specificLoads)
    {
        //Get the Loads for the currentLoads
        var specificLoadIds = specificLoads.Select(x => x.LoadId.ToString()).ToList();
        var loadFilter = new FilterGenerator<Load>().GetFilterForPropertyByListOfIds("Id", specificLoadIds);
        var loadResponse = await _managerService.LoadManager().GetAsync(loadFilter);

        //Get the Devices for the currentLoads
        var deviceIds = specificLoads.Select(x => x.DeviceId.ToString()).ToList();
        var deviceVms = await _platformService.GetDeviceVmsByListOfIds(deviceIds);

        if (loadResponse.Data is not null)
        {
            var specificLoadVms = specificLoads.Select(load => new SpecificLoadVm
            {
                Id = load.Id,
                LoadId = load.LoadId,
                DeviceId = load.DeviceId,
                LoadName = loadResponse.Data.FirstOrDefault(i => i.Id == load.LoadId).Name,
                Device = deviceVms.FirstOrDefault(i => i.Id == load.DeviceId).Device
            });
            return specificLoadVms;
        }

        return new List<SpecificLoadVm>();
    }
    public async Task<IEnumerable<SpecificLoadVm>> GetSpecificLoadVmsByLoadId(int id)
    {
        //SELECT * FROM CurrentLoads ---> **--WHERE LoadId = id--**
        var loadFilter = new FilterGenerator<SpecificLoad>().GetFilterWherePropertyEqualsValue("LoadId", id);
        var specificLoadResponse = await _managerService.SpecificLoadManager().GetAsync(loadFilter);
        if (specificLoadResponse.Data is not null)
            return await MapSpecificLoadsToSpecificLoadVms(specificLoadResponse.Data);
        return new List<SpecificLoadVm>();
    }
    #endregion

    #region --Tasks--
    public async Task<LoadVm> GetLoadVmById(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT l.Id, l.Name, l.HardwareConfigId, l.IsAccepted " +
                $"FROM Loads l " +
                $"WHERE l.Id = @LoadId",
            Parameters = new Dictionary<string, int> { { "LoadId", id } }
        };
        return await _managerService.LoadVmManager().GetByIdAsync(id, adhocRequest);
    }
    public async Task<CurrentLoadVm> GetCurrentLoadVmById(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT cl.Id, cl.LoadId, cl.DeviceId, l.Name[LoadName], d.Name[Device] " +
                $"FROM CurrentLoads cl " +
                $"INNER JOIN Devices d ON d.Id = cl.DeviceId " +
                $"INNER JOIN Loads l ON l.Id = cl.LoadId " +
                $"WHERE cl.Id = @Id",
            Parameters = new Dictionary<string, int> { { "Id", id } }
        };
        return await _managerService.CurrentLoadVmManager().GetByIdAsync(id, adhocRequest);
    }
    public async Task<SpecificLoadVm> GetSpecificLoadVmById(int id)
    {
        var specificLoad = await _managerService.SpecificLoadManager().GetByIdAsync(id);
        return await this.MapSpecificLoadToSpecificLoadVm(specificLoad);
    }
    public async Task<SpecificLoad> GetSpecificLoadFromSpecificLoadVm(SpecificLoadVm specificLoadVm)
    {
        var specificLoad = new SpecificLoad()
        {
            Id = specificLoadVm.Id,
            DeviceId = specificLoadVm.DeviceId,
            LoadId = specificLoadVm.LoadId
        };
        return await Task.Run(() => specificLoad);
    }
    public async Task<SpecificLoadVm> MapSpecificLoadToSpecificLoadVm(SpecificLoad specificLoad)
    {
        var device = await _platformService.GetDeviceVmById(specificLoad.Id);
        var load = await _managerService.LoadManager().GetByIdAsync(specificLoad.LoadId);
        var specificLoadVm = new SpecificLoadVm()
        {
            Id = specificLoad.Id,
            LoadId = specificLoad.LoadId,
            DeviceId = specificLoad.DeviceId,
            Device = device.Device,
            LoadName = load.Name
        };
        return specificLoadVm;
    }
    public async Task AddSoftwareVersionToLoad()
    {
        var loadId = _appState.LoadVm.Id;
        var vms = _appState.VersionsLoadVms.ToList();
        var softwareSystemId = _appState.SoftwareSystemVm.Id;

        List<int> softwareSystemIds = new List<int>();
        foreach (var v in vms)
        {
            var versionVm = await _softwareService.GetSoftwareVersionVmById(v.SoftwareVersionId);
            softwareSystemIds.Add(versionVm.SoftwareSystemId);
        }

        if (softwareSystemIds.Contains(softwareSystemId))
        {
            var index = softwareSystemIds.IndexOf(softwareSystemId);
            var versionLoadIdToRemove = vms[index].Id;

            //THE ID is the same as the SoftwareVersionId?
            
            await _managerService.VersionsLoadManager().DeleteByIdAsync(versionLoadIdToRemove);
        }

        var loadVersionToAdd = new VersionsLoad() { LoadId = loadId, SoftwareVersionId = _appState.SoftwareVersionVm.Id };
        var result = await _managerService.VersionsLoadManager().InsertAsync(loadVersionToAdd);
    }

    #endregion

}
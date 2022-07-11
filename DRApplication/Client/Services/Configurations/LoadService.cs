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
    public async Task<IEnumerable<LoadVm>> GetLoadVmByDeviceTypeId(int id)
    {
        var filter = new QueryFilter<Load>();
        var filterProperties = new List<FilterProperty>();
        filterProperties.Add(new FilterProperty()
        {
            Name = "DeviceTypeId",
            Value = id.ToString(),
            Operator = FilterQueryOperator.Equals
        });
        filter.OrderByDescending = true;
        filter.PaginationFilter = null;
        filter.FilterProperties = filterProperties;

        var loadResponse = await _managerService.LoadManager().GetAsync(filter);
        var loads = loadResponse.Data;

        if (loads is not null)
            return _mapperService.LoadVmsFromLoads(loads);

        return new List<LoadVm>();

    }
    public async Task<IEnumerable<LoadVm>> GetLoadVmsByHardwareConfigId(int id)
    {
        var filter = new QueryFilter<Load>();
        var filterProperties = new List<FilterProperty>();
        filterProperties.Add(new FilterProperty()
        {
            Name = "HardwareConfigId",
            Value = id.ToString(),
            Operator = FilterQueryOperator.Equals
        });
        filter.OrderByDescending = true;
        filter.PaginationFilter = null;
        filter.FilterProperties = filterProperties;

        var loadResponse = await _managerService.LoadManager().GetAsync(filter);
        var loads = loadResponse.Data;

        if (loads is not null)
            return _mapperService.LoadVmsFromLoads(loads);

        return new List<LoadVm>();
    }
    public async Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id)
    {
        try
        {
            var versionsLoads = await _loadHelpers.GetVersionsLoadsByLoadIdAsync(id);

            var versionLoadsVms = await _mapperService.VersionsLoadVmsFromVersionsLoadAsync(versionsLoads);
            return versionLoadsVms.OrderBy(i => i.SoftwareSystemName);

        }
        catch
        {
            //TODO: Log Error
            return new List<VersionsLoadVm>();
        }
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
    public async Task<IEnumerable<CurrentLoadVm>> MapCurrentLoadsToCurrentLoadVms(IEnumerable<CurrentLoad> currentLoads)
    {
        //Get the Loads for the currentLoads
        var currentLoadIds = currentLoads.Select(x => x.LoadId.ToString()).ToList();
        var loadFilter = new FilterGenerator<Load>().GetFilterForPropertyByListOfIds("Id", currentLoadIds);
        var loadResponse = await _managerService.LoadManager().GetAsync(loadFilter);

        //Get the Devices for the currentLoads
        var deviceIds = currentLoads.Select(x => x.DeviceId.ToString()).ToList();
        var deviceVms = await _platformService.GetDeviceVmsByListOfIds(deviceIds);

        if (loadResponse.Data is not null)
        {
            var currentLoadVms = currentLoads.Select(load => new CurrentLoadVm
            {
                Id = load.Id,
                LoadId = load.LoadId,
                DeviceId = load.DeviceId,
                LoadName = loadResponse.Data.FirstOrDefault(i => i.Id == load.LoadId).Name,
                Device = deviceVms.FirstOrDefault(i => i.Id == load.DeviceId).Device
            });
            return currentLoadVms;
        }

        return new List<CurrentLoadVm>();
    }
    public async Task<IEnumerable<SpecificLoadVm>> GetSpecificLoadVmsByDeviceTypeId(int id)
    {
        //TODO: Use Ad Hoc Dapper
        //first, get a list of devices for the DeviceTypeID (ID)
        var deviceVms = await _platformService.GetDeviceVmsFromDeviceTypeId(id);

        var deviceIds = deviceVms.Select(x => x.Id.ToString()).ToList();

        var specificLoadFilter = new FilterGenerator<SpecificLoad>().GetFilterForPropertyByListOfIds("DeviceId", deviceIds);
        var specificLoadResponse = await _managerService.SpecificLoadManager().GetAsync(specificLoadFilter);

        if (specificLoadResponse is not null && specificLoadResponse.Data is not null)
            return await this.MapSpecificLoadsToSpecificLoadVms(specificLoadResponse.Data);

        return new List<SpecificLoadVm>();
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
        var load = await _managerService.LoadManager().GetByIdAsync(id);
        var loadVm = new LoadVm()
        {
            Id = load.Id,
            HardwareConfigId = load.HardwareConfigId,
            IsAccepted = load.IsAccepted,
            Name = load.Name
        };
        return loadVm;
    }
    public async Task<CurrentLoadVm> GetCurrentLoadVmById(int id)
    {
        var currentLoad = await _managerService.CurrentLoadManager().GetByIdAsync(id);
        return await this.MapCurrentLoadToCurrentLoadVm(currentLoad);
    }
    
    public async Task<CurrentLoadVm> MapCurrentLoadToCurrentLoadVm(CurrentLoad currentLoad)
    {
        var device = await _platformService.GetDeviceVmById(currentLoad.Id);
        var load = await _managerService.LoadManager().GetByIdAsync(currentLoad.LoadId);
        var currentLoadVm = new CurrentLoadVm()
        {
            Id = currentLoad.Id,
            LoadId = currentLoad.LoadId,
            DeviceId = currentLoad.DeviceId,
            Device = device.Device,
            LoadName = load.Name
        };
        return currentLoadVm;
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
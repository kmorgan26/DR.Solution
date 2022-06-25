using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class LoadService : ILoadService
{

    #region ---Fields and Constructor ---

    private readonly IPlatformService _platformService;
    private readonly ISoftwareService _softwareService;
    private readonly ManagerService _managerService;
    private readonly AppState _appState;

    public LoadService(
            IPlatformService platformService,
            ISoftwareService softwareService,
            ManagerService managerService,
            AppState appState
        )
    {
        _platformService = platformService;
        _softwareService = softwareService;
        _managerService = managerService;
        _appState = appState;
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

        var response = await _managerService.LoadManager().GetAsync(filter);

        if (response is not null)
            return Mapping.Mapper.Map<IEnumerable<LoadVm>>(response.Data);

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

        var response = await _managerService.LoadManager().GetAsync(filter);

        if (response is not null)
            return Mapping.Mapper.Map<IEnumerable<LoadVm>>(response.Data);

        return new List<LoadVm>();
    }
    public async Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id)
    {
        try
        {
            var versionLoadsFilter = await new FilterGenerator<VersionsLoad>().GetFilterWherePropertyEqualsValueAsync("LoadId", id);
            var versionLoadresponse = await _managerService.VersionsLoadManager().GetAsync(versionLoadsFilter);
            var mappedVersionLoads = Mapping.Mapper.Map<IEnumerable<VersionsLoadVm>>(versionLoadresponse.Data);

            var versionIds = mappedVersionLoads.Select(x => x.SoftwareVersionId.ToString()).ToList();
            var softwareVersions = await _softwareService.GetSoftwareVersionsByIds(versionIds);

            var systemIds = softwareVersions.Select(x => x.SoftwareSystemId.ToString()).ToList();

            var softwareSystems = await _softwareService.GetSoftwareSystemsByIds(systemIds);

            var ids = mappedVersionLoads?.Select(x => x.SoftwareVersionId.ToString()).ToList();

            foreach (var item in mappedVersionLoads)
            {
                item.SoftwareVersionName = softwareVersions.Where(i => i.Id == item.SoftwareVersionId).FirstOrDefault().Name;
                var version = softwareVersions.Where(i => i.Id == item.SoftwareVersionId).FirstOrDefault();
                item.SoftwareSystemName = softwareSystems.Where(a => a.Id == version.SoftwareSystemId).FirstOrDefault().Name;
            }
            return mappedVersionLoads.OrderBy(i => i.SoftwareSystemName);
        }
        catch (Exception ex)
        {
            return new List<VersionsLoadVm>();
        }
    }
    public async Task<IEnumerable<CurrentLoadVm>> GetCurrentLoadVmsByDeviceTypeId(int id)
    {
        //first, get a list of devices for the DeviceTypeID (ID)
        var deviceVms = await _platformService.GetDeviceVmsFromDeviceTypeId(id);
        var deviceIds = deviceVms.Select(x => x.Id.ToString()).ToList();

        var currentLoadFilter = await new FilterGenerator<CurrentLoad>().GetFilterForPropertyByListOfIdsAsync("DeviceId", deviceIds);
        var currentLoadResponse = await _managerService.CurrentLoadManager().GetAsync(currentLoadFilter);

        if(currentLoadResponse is not null && currentLoadResponse.Data is not null)
            return await this.MapCurrentLoadsToCurrentLoadVms(currentLoadResponse.Data);
        
        return new List<CurrentLoadVm>();
    }
    public async Task<IEnumerable<CurrentLoadVm>> MapCurrentLoadsToCurrentLoadVms(IEnumerable<CurrentLoad> currentLoads)
    {
        //Get the Loads for the currentLoads
        var currentLoadIds = currentLoads.Select(x => x.LoadId.ToString()).ToList();
        var loadFilter = await new FilterGenerator<Load>().GetFilterForPropertyByListOfIdsAsync("Id", currentLoadIds);
        var loadResponse = await _managerService.LoadManager().GetAsync(loadFilter);

        //Get the Devices for the currentLoads
        var deviceVms = await _platformService.GetDeviceVmsByCsvOfIds(currentLoadIds);

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
        //first, get a list of devices for the DeviceTypeID (ID)
        var deviceVms = await _platformService.GetDeviceVmsFromDeviceTypeId(id);

        var deviceIds = deviceVms.Select(x => x.Id.ToString()).ToList();

        var specificLoadFilter = await new FilterGenerator<SpecificLoad>().GetFilterForPropertyByListOfIdsAsync("DeviceId", deviceIds);
        var specificLoadResponse = await _managerService.SpecificLoadManager().GetAsync(specificLoadFilter);

        if (specificLoadResponse is not null && specificLoadResponse.Data is not null)
            return await this.MapSpecificLoadsToSpecificLoadVms(specificLoadResponse.Data);

        return new List<SpecificLoadVm>();
    }
    public async Task<IEnumerable<SpecificLoadVm>> MapSpecificLoadsToSpecificLoadVms(IEnumerable<SpecificLoad> specificLoads)
    {
        //Get the Loads for the currentLoads
        var specificLoadIds = specificLoads.Select(x => x.LoadId.ToString()).ToList();
        var loadFilter = await new FilterGenerator<Load>().GetFilterForPropertyByListOfIdsAsync("Id", specificLoadIds);
        var loadResponse = await _managerService.LoadManager().GetAsync(loadFilter);

        //Get the Devices for the currentLoads
        var deviceVms = await _platformService.GetDeviceVmsByCsvOfIds(specificLoadIds);

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
        //SELECT * FROM CurrentLoads ---> **--WHERE LoadId = id--**
        var loadFilter = await new FilterGenerator<CurrentLoad>().GetFilterWherePropertyEqualsValueAsync("LoadId", id);
        var currentLoadResponse = await _managerService.CurrentLoadManager().GetAsync(loadFilter);
        if (currentLoadResponse.Data is not null)
            return await MapCurrentLoadsToCurrentLoadVms(currentLoadResponse.Data);
        return new List<CurrentLoadVm>();
    }
    public async Task<IEnumerable<SpecificLoadVm>> GetSpecificLoadVmsByLoadId(int id)
    {
        //SELECT * FROM CurrentLoads ---> **--WHERE LoadId = id--**
        var loadFilter = await new FilterGenerator<SpecificLoad>().GetFilterWherePropertyEqualsValueAsync("LoadId", id);
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
    public async Task<CurrentLoad> GetCurrentLoadFromCurrentLoadVm(CurrentLoadVm currentLoadVm)
    {
        var currentLoad = new CurrentLoad()
        {
            Id = currentLoadVm.Id,
            DeviceId = currentLoadVm.DeviceId,
            LoadId = currentLoadVm.LoadId
        };
        return await Task.Run(() => currentLoad);
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

            //var versionLoad = Mapping.Mapper.Map<VersionsLoad>(versionLoadVmToRemove);
            await _managerService.VersionsLoadManager().DeleteByIdAsync(versionLoadIdToRemove);
        }

        var loadVersionToAdd = new VersionsLoad() { LoadId = loadId, SoftwareVersionId = _appState.SoftwareVersionVm.Id };
        var result = await _managerService.VersionsLoadManager().InsertAsync(loadVersionToAdd);
    }

    #endregion

}
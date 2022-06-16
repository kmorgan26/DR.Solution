using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services;

public class LoadBuilderService : ILoadBuilderService
{

    #region ---Fields and Constructor ---

    private readonly IPlatformService _platformService;
    private readonly SoftwareSystemManager _softwareSystemManager;
    private readonly SoftwareVersionManager _softwareVersionManager;
    private readonly SpecificLoadManager _specificLoadManager;
    private readonly LoadManager _loadManager;
    private readonly DeviceManager _deviceManager;
    private readonly CurrentLoadManager _currentLoadManager;
    private readonly VersionsLoadManager _versionsLoadManager;
    private readonly AppState _appState;

    public LoadBuilderService(
            IPlatformService platformService,
            SoftwareSystemManager softwareSystemManager,
            SoftwareVersionManager softwareVersionManager,
            SpecificLoadManager specificLoadManager,
            LoadManager loadManager,
            DeviceManager deviceManager,
            CurrentLoadManager currentLoadManager,
            VersionsLoadManager versionsLoadManager,
            AppState appState
        )
    {
        _platformService = platformService;
        _softwareSystemManager = softwareSystemManager;
        _softwareVersionManager = softwareVersionManager;
        _specificLoadManager = specificLoadManager;
        _loadManager = loadManager;
        _deviceManager = deviceManager;
        _currentLoadManager = currentLoadManager;
        _versionsLoadManager = versionsLoadManager;
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

        var response = await _loadManager.GetAsync(filter);

        if (response is not null)
            return Mapping.Mapper.Map<IEnumerable<LoadVm>>(response.Data);

        return new List<LoadVm>();

    }
    public async Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id)
    {
        try
        {
            var versionLoadsFilter = await new FilterGenerator<VersionsLoad>().GetFilterForPropertyByNameAsync("LoadId", id);
            var versionLoadresponse = await _versionsLoadManager.GetAsync(versionLoadsFilter);
            var mappedVersionLoads = Mapping.Mapper.Map<IEnumerable<VersionsLoadVm>>(versionLoadresponse.Data);

            var versionIds = mappedVersionLoads.Select(x => x.SoftwareVersionId.ToString()).ToList();
            var versionCsv = string.Join(",", versionIds);

            var versionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByListOfIdsAsync("Id", versionCsv);
            var versionResponse = await _softwareVersionManager.GetAsync(versionFilter);

            var systemIds = versionResponse.Data?.Select(x => x.SoftwareSystemId.ToString()).ToList();
            var systemCsv = string.Join(",", systemIds);

            var systemFilter = await new FilterGenerator<SoftwareSystem>().GetFilterForPropertyByListOfIdsAsync("Id", systemCsv);
            var systemResponse = await _softwareSystemManager.GetAsync(systemFilter);

            var ids = mappedVersionLoads?.Select(x => x.SoftwareVersionId.ToString()).ToList();

            foreach (var item in mappedVersionLoads)
            {
                item.SoftwareVersionName = versionResponse.Data.Where(i => i.Id == item.SoftwareVersionId).FirstOrDefault().Name;
                var version = versionResponse.Data.Where(i => i.Id == item.SoftwareVersionId).FirstOrDefault();
                item.SoftwareSystemName = systemResponse.Data.Where(a => a.Id == version.SoftwareSystemId).FirstOrDefault().Name;
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

        var deviceIds = deviceVms.Select(x => x.Id).ToList();
        var deviceCsv = string.Join(",", deviceIds);

        var currentLoadFilter = await new FilterGenerator<CurrentLoad>().GetFilterForPropertyByListOfIdsAsync("DeviceId", deviceCsv);
        var currentLoadResponse = await _currentLoadManager.GetAsync(currentLoadFilter);

        if(currentLoadResponse is not null && currentLoadResponse.Data is not null)
            return await this.MapCurrentLoadsToCurrentLoadVms(currentLoadResponse.Data);
        
        return new List<CurrentLoadVm>();
    }
    #endregion

    #region --Tasks--
    public async Task<IEnumerable<SpecificLoadVm>> GetSpecificLoadVmsByDeviceTypeId(int id)
    {
        //first, get a list of devices for the DeviceTypeID (ID)
        var deviceVms = await _platformService.GetDeviceVmsFromDeviceTypeId(id);

        var deviceIds = deviceVms.Select(x => x.Id).ToList();
        var deviceCsv = string.Join(",", deviceIds);

        var specificLoadFilter = await new FilterGenerator<SpecificLoad>().GetFilterForPropertyByListOfIdsAsync("DeviceId", deviceCsv);
        var specificLoadResponse = await _specificLoadManager.GetAsync(specificLoadFilter);

        if (specificLoadResponse is not null && specificLoadResponse.Data is not null)
            return await this.MapSpecificLoadsToSpecificLoadVms(specificLoadResponse.Data);

        return new List<SpecificLoadVm>();
    }
    public async Task AddSoftwareVersionToLoad()
    {
        var loadId = _appState.LoadVm.Id;
        var vms = _appState.VersionsLoadVms.ToList();
        var softwareSystemId = _appState.SoftwareSystemVm.Id;

        List<int> softwareSystemIds = new List<int>();
        foreach (var v in vms)
        {
            var versionVm = await _softwareVersionManager.GetByIdAsync(v.SoftwareVersionId);
            softwareSystemIds.Add(versionVm.SoftwareSystemId);
        }

        if (softwareSystemIds.Contains(softwareSystemId))
        {
            var index = softwareSystemIds.IndexOf(softwareSystemId);
            var versionLoadIdToRemove = vms[index].Id;

            //THE ID is the same as the SoftwareVersionId?

            //var versionLoad = Mapping.Mapper.Map<VersionsLoad>(versionLoadVmToRemove);
            await _versionsLoadManager.DeleteByIdAsync(versionLoadIdToRemove);
        }

        var loadVersionToAdd = new VersionsLoad() { LoadId = loadId, SoftwareVersionId = _appState.SoftwareVersionVm.Id };
        var result = await _versionsLoadManager.InsertAsync(loadVersionToAdd);
    }
    public async Task<IEnumerable<CurrentLoadVm>> MapCurrentLoadsToCurrentLoadVms(IEnumerable<CurrentLoad> currentLoads)
    {
        //Get the Loads for the currentLoads
        var currentLoadCsv = string.Join(",", currentLoads.Select(id => id.LoadId).ToList());
        var loadFilter = await new FilterGenerator<Load>().GetFilterForPropertyByListOfIdsAsync("Id", currentLoadCsv);
        var loadResponse = await _loadManager.GetAsync(loadFilter);

        //Get the Devices for the currentLoads
        var deviceCsv = string.Join(",", currentLoads.Select(id => id.DeviceId).ToList());
        var deviceFilter = await new FilterGenerator<Device>().GetFilterForPropertyByListOfIdsAsync("Id", deviceCsv);
        var deviceResponse = await _deviceManager.GetAsync(deviceFilter);


        if (loadResponse.Data is not null)
        {
            var currentLoadVms = currentLoads.Select(load => new CurrentLoadVm
            {
                Id = load.Id,
                LoadId = load.LoadId,
                DeviceId = load.DeviceId,
                LoadName = loadResponse.Data.FirstOrDefault(i => i.Id == load.LoadId).Name,
                Device = deviceResponse.Data.FirstOrDefault(i => i.Id == load.DeviceId).Name
            });
            return currentLoadVms;
        }

        return new List<CurrentLoadVm>();
    }
    public async Task<IEnumerable<SpecificLoadVm>> MapSpecificLoadsToSpecificLoadVms(IEnumerable<SpecificLoad> specificLoads)
    {
        //Get the Loads for the currentLoads
        var specificLoadCsv = string.Join(",", specificLoads.Select(id => id.LoadId).ToList());
        var loadFilter = await new FilterGenerator<Load>().GetFilterForPropertyByListOfIdsAsync("Id", specificLoadCsv);
        var loadResponse = await _loadManager.GetAsync(loadFilter);

        //Get the Devices for the currentLoads
        var deviceCsv = string.Join(",", specificLoads.Select(id => id.DeviceId).ToList());
        var deviceFilter = await new FilterGenerator<Device>().GetFilterForPropertyByListOfIdsAsync("Id", deviceCsv);
        var deviceResponse = await _deviceManager.GetAsync(deviceFilter);


        if (loadResponse.Data is not null)
        {
            var specificLoadVms = specificLoads.Select(load => new SpecificLoadVm
            {
                Id = load.Id,
                LoadId = load.LoadId,
                DeviceId = load.DeviceId,
                LoadName = loadResponse.Data.FirstOrDefault(i => i.Id == load.LoadId).Name,
                Device = deviceResponse.Data.FirstOrDefault(i => i.Id == load.DeviceId).Name
            });
            return specificLoadVms;
        }

        return new List<SpecificLoadVm>();
    }
    public async Task<CurrentLoadVm> MapCurrentLoadToCurrentLoadVm(CurrentLoad currentLoad)
    {
        var device = await _deviceManager.GetByIdAsync(currentLoad.Id);
        var load = await _loadManager.GetByIdAsync(currentLoad.LoadId);
        var currentLoadVm = new CurrentLoadVm()
        {
            Id = currentLoad.Id,
            LoadId = currentLoad.LoadId,
            DeviceId = currentLoad.DeviceId,
            Device = device.Name,
            LoadName = load.Name
        };
        return currentLoadVm;
    }
    public async Task<SpecificLoadVm> MapSpecificLoadToSpecificLoadVm(SpecificLoad specificLoad)
    {
        var device = await _deviceManager.GetByIdAsync(specificLoad.Id);
        var load = await _loadManager.GetByIdAsync(specificLoad.LoadId);
        var specificLoadVm = new SpecificLoadVm()
        {
            Id = specificLoad.Id,
            LoadId = specificLoad.LoadId,
            DeviceId = specificLoad.DeviceId,
            Device = device.Name,
            LoadName = load.Name
        };
        return specificLoadVm;
    }

    public async Task<CurrentLoadVm> GetCurrentLoadVmById(int id)
    {
        var currentLoad = await _currentLoadManager.GetByIdAsync(id);
        return await this.MapCurrentLoadToCurrentLoadVm(currentLoad);
    }
    public async Task<SpecificLoadVm> GetSpecificLoadVmById(int id)
    {
        var specificLoad = await _specificLoadManager.GetByIdAsync(id);
        return await this.MapSpecificLoadToSpecificLoadVm(specificLoad);
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

    public async Task<LoadVm> GetLoadVmById(int id)
    {
        var load = await _loadManager.GetByIdAsync(id);
        var loadVm = new LoadVm()
        {
            Id = load.Id,
            HardwareConfigId = load.HardwareConfigId,
            IsAccepted = load.IsAccepted,
            Name = load.Name
        };
        return loadVm;
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

        var response = await _loadManager.GetAsync(filter);

        if (response is not null)
            return Mapping.Mapper.Map<IEnumerable<LoadVm>>(response.Data);

        return new List<LoadVm>();
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

    #endregion
}
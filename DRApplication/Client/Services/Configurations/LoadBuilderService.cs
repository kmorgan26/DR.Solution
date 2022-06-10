using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services;

public class LoadBuilderService : ILoadBuilderService
{
    private readonly SoftwareSystemManager _softwareSystemManager;
    private readonly SoftwareVersionManager _softwareVersionManager;
    private readonly LoadManager _loadManager;
    private readonly VersionsLoadManager _versionsLoadManager;
    private readonly AppState _appState;

    public LoadBuilderService(
            SoftwareSystemManager softwareSystemManager,
            SoftwareVersionManager softwareVersionManager,
            LoadManager loadManager,
            VersionsLoadManager versionsLoadManager,
            AppState appState
        )
    {
        _softwareSystemManager = softwareSystemManager;
        _softwareVersionManager = softwareVersionManager;
        _loadManager = loadManager;
        _versionsLoadManager = versionsLoadManager;
        _appState = appState;
    }

    
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
    /// <summary>
    /// Returns a list of LoadVms for a given Load
    /// </summary>
    /// <param name="id">
    ///    This is the Id from the Loads Table
    /// </param>
    public async Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id)
    {
        try
        {
            var versionLoadsFilter = await new FilterGenerator<VersionsLoad>().GetFilterForPropertyByNameAsync("LoadId", id);
            var response = await _versionsLoadManager.GetAsync(versionLoadsFilter);
            var versionLoads = response.Data;

            var mappedLoads = Mapping.Mapper.Map<IEnumerable<VersionsLoadVm>>(versionLoads);

            var versionIds = mappedLoads.Select(x => x.SoftwareVersionId.ToString()).ToList();
            var versionCsv = string.Join(",", versionIds);
            var versionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByListOfIdsAsync("Id", versionCsv);
            var versionResponse = await _softwareVersionManager.GetAsync(versionFilter);
            var softwareVersions = versionResponse.Data;

            var systemIds = softwareVersions?.Select(x => x.SoftwareSystemId.ToString()).ToList();
            var systemCsv = string.Join(",", systemIds);
            var systemFilter = await new FilterGenerator<SoftwareSystem>().GetFilterForPropertyByListOfIdsAsync("Id", systemCsv);
            var systemResponse = await _softwareSystemManager.GetAsync(systemFilter);
            var softwareSystems = systemResponse.Data;

            var ids = mappedLoads?.Select(x => x.SoftwareVersionId.ToString()).ToList();

            foreach (var item in mappedLoads)
            {
                item.SoftwareVersionName = softwareVersions.Where(i => i.Id == item.SoftwareVersionId).FirstOrDefault().Name;
                var version = softwareVersions.Where(i => i.Id == item.SoftwareVersionId).FirstOrDefault();
                item.SoftwareSystemName = softwareSystems.Where(a => a.Id == version.SoftwareSystemId).FirstOrDefault().Name;
            }
            return mappedLoads.OrderBy(i => i.SoftwareSystemName);
        }
        catch (Exception ex)
        {

            return new List<VersionsLoadVm>();
        }
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
}
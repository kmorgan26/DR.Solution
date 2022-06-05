using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services;

public class LoadBuilderService : ILoadBuilderService
{
    private readonly HardwareConfigManager _hardwareConfigManager;
    private readonly SoftwareSystemManager _softwareSystemManager;
    private readonly SoftwareVersionManager _softwareVersionManager;
    private readonly LoadManager _loadManager;
    private readonly VersionsLoadManager _versionsLoadManager;

    public LoadBuilderService(
            HardwareConfigManager hardwareConfigManager,
            SoftwareSystemManager softwareSystemManager,
            SoftwareVersionManager softwareVersionManager,
            LoadManager loadManager,
            VersionsLoadManager versionsLoadManager
        )
    {
        _hardwareConfigManager = hardwareConfigManager;
        _softwareSystemManager = softwareSystemManager;
        _softwareVersionManager = softwareVersionManager;
        _loadManager = loadManager;
        _versionsLoadManager = versionsLoadManager;
    }

    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int id)
    {
        var filter = await new FilterGenerator<HardwareConfig>().GetFilterForPropertyByNameAsync("DeviceTypeId", id);
        var response = await _hardwareConfigManager.GetAsync(filter);

        if (response.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<HardwareConfigVm>>(response.Data);

        return new List<HardwareConfigVm>();
    }

    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        var config = await _hardwareConfigManager.GetByIdAsync(id);
        if (config == null)
            return new HardwareConfigVm();

        return Mapping.Mapper.Map<HardwareConfigVm>(config);
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

    public async Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemVmsByHardwareConfigId(int id)
    {
        var systems = await _softwareSystemManager.GetAllAsync();
        var filterd = systems.Where(x => x.HardwareConfigId == id);
        return Mapping.Mapper.Map<IEnumerable<SoftwareSystemVm>>(filterd);
    }

    public async Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id)
    {
        var softwareSystem = await _softwareSystemManager.GetByIdAsync(id);
        if (softwareSystem == null)
            return new SoftwareSystemVm();

        return Mapping.Mapper.Map<SoftwareSystemVm>(softwareSystem);
    }

    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id)
    {
        var filter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByNameAsync("SoftwareSystemId", id);

        var response = await _softwareVersionManager.GetAsync(filter);

        if (response.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<SoftwareVersionVm>>(response.Data);

        return new List<SoftwareVersionVm>();

    }

    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsByLoadId(int id)
    {
        var filter = await new FilterGenerator<VersionsLoad>().GetFilterForPropertyByNameAsync("LoadId", id);
        var response = await _versionsLoadManager.GetAsync(filter);

        List<string> softwareVersionIdList = new List<string>();
        foreach (var item in response.Data)
        {
            softwareVersionIdList.Add(item.SoftwareVersionId.ToString());
        }
        var softVersionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertiesByNamesAsync("SoftwareVersion", softwareVersionIdList);
        var softwareVersionResponse = await _softwareVersionManager.GetAsync(softVersionFilter);


        return Mapping.Mapper.Map<IEnumerable<SoftwareVersionVm>>(softwareVersionResponse.Data);

    }

    public async Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id)
    {
        var versionLoadsFilter = await new FilterGenerator<VersionsLoad>().GetFilterForPropertyByNameAsync("LoadId", id);
        var response = await _versionsLoadManager.GetAsync(versionLoadsFilter);
        var versionLoads = response.Data;

        //get a list of the software version IDs
        var ids = versionLoads?.Select(x => x.SoftwareVersionId.ToString()).ToList();
        string csv = string.Join(",", ids);

        if (ids is not null)
        {
            var softwareVersionFilter = await new FilterGenerator<SoftwareVersion>().GetFilterForPropertyByListOfIdsAsync("Id", csv);
            var softwareVersionResponse = await _softwareVersionManager.GetAsync(softwareVersionFilter);
            var softwareVersions = softwareVersionResponse.Data;

            var softwareSystemIds = softwareVersions?.Select(x => x.SoftwareSystemId.ToString()).ToList();

            string softwareSystemIdsCsv = string.Join(",", softwareSystemIds);

            //now get a list of Software Systems with those IDs
            if (softwareSystemIds is not null)
            {
                var softwareSystemFilter = await new FilterGenerator<SoftwareSystem>().GetFilterForPropertyByListOfIdsAsync("Id", softwareSystemIdsCsv);
                var softwareSystemResponse = await _softwareSystemManager.GetAsync(softwareSystemFilter);
                var softwareSystems = softwareSystemResponse.Data;

                var result = softwareVersions.Select(i => new VersionsLoadVm()
                {
                    SoftwareVersionId = i.Id,
                    Id = i.Id,
                    LoadId = id,
                    SoftwareVersionName = i.Name,
                    SoftwareSystemName = softwareSystems.Where(s => s.Id == i.SoftwareSystemId).FirstOrDefault().Name
                });

                if (result is not null)
                    return result;
            }


        }
        return new List<VersionsLoadVm>();
    }

}

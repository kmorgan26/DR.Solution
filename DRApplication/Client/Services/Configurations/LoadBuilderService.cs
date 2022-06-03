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

    //TODO: Use a filter to get ONLY by DeviceTypeId
    public async Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int i)
    {
        var configs = await _hardwareConfigManager.GetAllAsync();
        var filtered = configs.Where(x => x.DeviceTypeId == i);
        return Mapping.Mapper.Map<IEnumerable<HardwareConfigVm>>(filtered);
    }

    public async Task<HardwareConfigVm> GetHardwareConfigVmById(int id)
    {
        var config = await _hardwareConfigManager.GetByIdAsync(id);
        if(config == null)
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

    //TODO: Create a filter helper to write these filters
    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id)
    {
        var filter = new QueryFilter<SoftwareVersion>();
        var filterProperties = new List<FilterProperty>();
        filterProperties.Add(new FilterProperty()
        { 
            Name = "SoftwareSystemId", 
            Value = id.ToString(), 
            Operator = FilterQueryOperator.Equals });
        filter.OrderByDescending = true;
        filter.OrderByPropertyName = "VersionDate";
        filter.PaginationFilter = null;

        filter.FilterProperties = filterProperties;
        var response = await _softwareVersionManager.GetAsync(filter);

        if (response.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<SoftwareVersionVm>>(response.Data);

        return new List<SoftwareVersionVm>();

    }

    public async Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id)
    {
        var filter = new QueryFilter<VersionsLoad>();
        var filterProperties = new List<FilterProperty>();
        filterProperties.Add(new FilterProperty()
        {
            Name = "LoadId",
            Value = id.ToString(),
            Operator = FilterQueryOperator.Equals
        });
        filter.OrderByDescending = true;
        filter.OrderByPropertyName = "Id";
        filter.PaginationFilter = null;

        filter.FilterProperties = filterProperties;
        var response = await _versionsLoadManager.GetAsync(filter);

        if(response.Data is not null)
            return Mapping.Mapper.Map<IEnumerable<VersionsLoadVm>>(response.Data);

        return new List<VersionsLoadVm>();
    }
}

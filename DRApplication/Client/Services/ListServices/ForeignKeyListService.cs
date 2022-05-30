using DRApplication.Shared.Enums;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Requests;

namespace DRApplication.Client.Services;

public class ForeignKeyListService : IForeignKeyListService
{
    private readonly HardwareConfigManager _hardwareConfigManager;
    private readonly LoadManager _loadManager;
    private readonly SoftwareSystemManager _softwareSystemManager;

    public ForeignKeyListService(HardwareConfigManager hardwareConfigManager, LoadManager loadManager, SoftwareSystemManager softwareSystemManager)
    {
        _hardwareConfigManager = hardwareConfigManager;
        _loadManager = loadManager;
        _softwareSystemManager = softwareSystemManager;
    }

    private IEnumerable<ForeignKeyListVm> vms = new List<ForeignKeyListVm>();

    public async Task<IEnumerable<ForeignKeyListVm>> GetForeignKeyListVmsFromPlatformListName(ForeignKeyListRequest request)
    {
        var filterproperties = GetFilterProperty(request);

        switch (request.TableName)
        {
            case PlatformListName.HardwareConfig :
                
                var hFilter = new QueryFilter<HardwareConfig>() { FilterProperties = filterproperties, PaginationFilter = null };
                var response = await _hardwareConfigManager.GetAsync(hFilter);

                vms = response!.Data!.Select(i => new ForeignKeyListVm
                {
                    Id = i.Id,
                    Name = i.Name,
                    ForeignKey = i.DeviceTypeId
                });
                return vms;

            case PlatformListName.Load:

                var lFilter = new QueryFilter<Load>() { FilterProperties = filterproperties, PaginationFilter = null};
                var lResponse = await _loadManager.GetAsync(lFilter);

                vms = lResponse!.Data!.Select(i => new ForeignKeyListVm
                {
                    Id = i.Id,
                    Name = i.Name,
                    ForeignKey = i.DeviceTypeId
                });
                return vms;
            case PlatformListName.SoftwareSystem:

                var sFilter = new QueryFilter<SoftwareSystem>() { FilterProperties = filterproperties, PaginationFilter = null };
                var sResponse = await _softwareSystemManager.GetAsync(sFilter);

                vms = sResponse!.Data!.Select(i => new ForeignKeyListVm
                {
                    Id = i.Id,
                    Name = i.Name,
                    ForeignKey = i.HardwareConfigId
                });
                return vms;
            default:
                return new List<ForeignKeyListVm>();
        }
    }

    private List<FilterProperty> GetFilterProperty(ForeignKeyListRequest request)
    {
        FilterProperty filterProperty = new FilterProperty();
        filterProperty.Name = request.ForeignKeyName; 
        filterProperty.Value = request.ForeignKeyValue;
        filterProperty.Operator = FilterQueryOperator.Equals;

        return new List<FilterProperty>() { filterProperty };
    }
}

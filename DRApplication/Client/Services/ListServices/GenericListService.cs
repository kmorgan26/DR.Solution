using DRApplication.Shared.Enums;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Services;

public class GenericListService : IGenericListService
{
    private readonly MaintainerManager _maintainerManager;
    private readonly DeviceTypeManager _deviceTypeManager;
    private readonly DeviceManager _deviceManager;
    private readonly HardwareConfigManager _hardwareConfigManager;

    public GenericListService(
        MaintainerManager maintainerManager,
        DeviceTypeManager deviceTypeManager,
        DeviceManager deviceManager,
        HardwareConfigManager hardwareConfigManager)
    {
        _maintainerManager = maintainerManager;
        _deviceTypeManager = deviceTypeManager;
        _deviceManager = deviceManager;
        _hardwareConfigManager = hardwareConfigManager;
    }

    private IEnumerable<GenericListVm> vms = new List<GenericListVm>();

    public async Task<IEnumerable<GenericListVm>> GetGenericListVmsFromPlatformListName(PlatformListName listType)
    {
        switch (listType)
        {
            case PlatformListName.Device:
                var devices = await _deviceManager.GetAllAsync();
                vms = devices.Select(i => new GenericListVm
                {
                    Id = i.Id,
                    Name = i.Name
                });
                return vms;
            case PlatformListName.Platform:
                var deviceTypes = await _deviceTypeManager.GetAllAsync();
                vms = deviceTypes.Select(i => new GenericListVm
                {
                    Id = i.Id,
                    Name = i.Name
                });
                return vms;
            case PlatformListName.Maintainer:
                var maintainers = await _maintainerManager.GetAllAsync();
                vms = maintainers.Select(i => new GenericListVm
                {
                    Id = i.Id,
                    Name = i.Name
                });
                return vms;
            case PlatformListName.HardwareConfig:
                var items = await _hardwareConfigManager.GetAllAsync();
                vms = items.Select(i => new GenericListVm
                {
                    Id = i.Id,
                    Name = i.Name
                });
                return vms;
            default:
                return new List<GenericListVm>();
        }
    }
}

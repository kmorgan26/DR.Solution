using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Interfaces;

public interface IPlatformService
{
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync();
    Task<IEnumerable<DeviceVm>> GetDeviceVmsAsync();
    Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync();

    Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceListAsync(IEnumerable<Device> devices);

}

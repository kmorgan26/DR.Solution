using DRApplication.Client.ViewModels.Platform;
namespace DRApplication.Client.Interfaces;

public interface IPlatformService
{
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync();
    Task<IEnumerable<DeviceVm>> GetDeviceVmsAsync();
    Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync();

}

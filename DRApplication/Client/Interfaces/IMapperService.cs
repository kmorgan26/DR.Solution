using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface IMapperService
{
    Task<DeviceVm> DeviceVmFromDeviceAsync(Device device);
    Task<Device> DeviceFromDeviceVmAsync(DeviceVm deviceVm);

}

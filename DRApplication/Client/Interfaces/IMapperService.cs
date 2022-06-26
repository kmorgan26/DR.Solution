using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface IMapperService
{
    Task<DeviceVm> DeviceVmFromDeviceAsync(Device device);
    Task<Device> DeviceFromDeviceVmAsync(DeviceVm deviceVm);
    Task<Device> DeviceFromDeviceInserVm(DeviceInsertVm deviceInsertVm);
    Task<DeviceTypeVm> DeviceTypeVmFromDeviceTypeAsync(DeviceType deviceType);
    Task<DeviceType> DeviceTypeFromDeviceTypeVmAsync(DeviceTypeVm deviceTypeVm);

    Task<IEnumerable<DeviceVm>> DeviceVmsFromDevices(IEnumerable<Device> devices);
    Task<IEnumerable<MaintainerVm>> MaintainerVmsFromMaintainers(IEnumerable<Maintainer> maintainers);
}
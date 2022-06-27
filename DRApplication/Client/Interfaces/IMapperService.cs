using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface IMapperService
{
    Task<Device> DeviceFromDeviceVmAsync(DeviceVm deviceVm);
    Task<Device> DeviceFromDeviceInsertVmAsync(DeviceInsertVm deviceInsertVm);
    Task<DeviceVm> DeviceVmFromDeviceAsync(Device device);
    Task<DeviceType> DeviceTypeFromDeviceTypeVmAsync(DeviceTypeVm deviceTypeVm);
    Task<DeviceType> DeviceTypeFromDeviceTypeInsertVmAsync(DeviceTypeInsertVm deviceTypeInsertVm);
    Task<DeviceTypeVm> DeviceTypeVmFromDeviceTypeAsync(DeviceType deviceType);
    Task<Maintainer> MaintainerFromMaintainerVmAsync(MaintainerVm maintainerVm);
    Task<MaintainerVm> MaintainerVmFromMaintainerAsync(Maintainer maintainer);
    Task<HardwareSystemVm> HardwareSystemVmFromHardwareSystemAsync(HardwareSystem hardwareSystem);
    Task<HardwareSystem> HardwareSystemFromHardwareSystemVmAsync(HardwareSystemVm hardwareSystemVm);
    Task<HardwareSystem> HardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm);
    Task<HardwareConfigVm> HardwareConfigVmFromHardwareConfigAsync(HardwareConfig hardwareConfig);
    Task<HardwareConfig> HardwareConfigFromHardwareConfigVmAsync(HardwareConfigVm hardwareConfigVm);
    Task<HardwareConfig> HardwareConfigFromHardwareConfigInsertVmAsync(HardwareConfigInsertVm hardwareConfigInsertVm);
    Task<HardwareVersionVm> HardwareVersionVmFromHardwareVersionsAsync(HardwareVersion hardwareVersion);
    Task<HardwareVersion> HardwareVersionFromHardwareVersionVmAsync(HardwareVersionVm hardwareVersionVm);
    Task<HardwareVersion> HardwareVersionFromHardwareVersionInsertVmAsync(HardwareVersionInsertVm hardwareVersionInsertVm);
    Task<IEnumerable<DeviceVm>> DeviceVmsFromDevicesAsync(IEnumerable<Device> devices);
    Task<IEnumerable<MaintainerVm>> MaintainerVmsFromMaintainersAsync(IEnumerable<Maintainer> maintainers);
    Task<IEnumerable<DeviceTypeVm>> DeviceTypeVmsFromDeviceTypesAsync(IEnumerable<DeviceType> deviceTypes);
    Task<IEnumerable<HardwareConfigVm>> HardwareConfigVmsFromHardwareConfigsAsync(IEnumerable<HardwareConfig> hardwareConfigs);
    Task<IEnumerable<HardwareSystemVm>> HardwareSystemVmsFromHardwareSystemsAsync(IEnumerable<HardwareSystem> hardwareSystems);
    Task<IEnumerable<HardwareVersionVm>> HardwareVersionVmsFromHardwareVersionsAsync(IEnumerable<HardwareVersion> hardwareVersions);

}
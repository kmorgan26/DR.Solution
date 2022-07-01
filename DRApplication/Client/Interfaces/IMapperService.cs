using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface IMapperService
{
    Task<Device> DeviceFromDeviceVmAsync(DeviceVm deviceVm);
    Task<Device> DeviceFromDeviceInsertVmAsync(DeviceInsertVm deviceInsertVm);
    Task<Device> DeviceFromDeviceEditVmAsync(DeviceEditVm deviceEditVm);
    Task<DeviceVm> DeviceVmFromDeviceAsync(Device device);
    Task<DeviceEditVm> DeviceEditVmFromDeviceAsync(Device device);
    Task<DeviceType> DeviceTypeFromDeviceTypeInsertVmAsync(DeviceTypeInsertVm deviceTypeInsertVm);
    Task<DeviceType> DeviceTypeFromDeviceTypeEditVmAsync(DeviceTypeEditVm deviceTypeEditVm);
    Task<DeviceTypeVm> DeviceTypeVmFromDeviceTypeAsync(DeviceType deviceType);
    Task<DeviceTypeEditVm> DeviceTypeEditVmFromDeviceTypeAsync(DeviceType deviceType);
    Task<DeviceTypeEditVm> DeviceTypeEditVmFromDeviceTypeVmAsync(DeviceTypeVm deviceTypeVm);
    Task<Maintainer> MaintainerFromMaintainerEditVmAsync(MaintainerEditVm maintainerEditVm);
    Task<MaintainerVm> MaintainerVmFromMaintainerAsync(Maintainer maintainer);
    Task<MaintainerEditVm> MaintainerEditVmFromMaintainerAsync(Maintainer maintainer);
    Task<HardwareSystemVm> HardwareSystemVmFromHardwareSystemAsync(HardwareSystem hardwareSystem);
    Task<HardwareSystemEditVm> HardwareSystemEditVmFromHardwareSystemAsync(HardwareSystem hardwareSystem);
    Task<HardwareSystem> HardwareSystemFromHardwareSystemVmAsync(HardwareSystemVm hardwareSystemVm);
    Task<HardwareSystem> HardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm);
    Task<HardwareSystem> HardwareSystemFromHardwareSystemEditVm(HardwareSystemEditVm hardwareSystemEditVm);
    Task<HardwareConfigVm> HardwareConfigVmFromHardwareConfigAsync(HardwareConfig hardwareConfig);
    Task<HardwareConfig> HardwareConfigFromHardwareConfigVmAsync(HardwareConfigVm hardwareConfigVm);
    Task<HardwareConfig> HardwareConfigFromHardwareConfigInsertVmAsync(HardwareConfigInsertVm hardwareConfigInsertVm);
    Task<HardwareVersionVm> HardwareVersionVmFromHardwareVersionAsync(HardwareVersion hardwareVersion);
    Task<HardwareVersionEditVm> HardwareVersionEditVmFromHardwareVersionAsync(HardwareVersion hardwareVersion);
    Task<HardwareVersionEditVm> HardwareVersionEditVmFromHardwareVersionVmAsync(HardwareVersionVm hardwareVersionVm);
    Task<HardwareVersion> HardwareVersionFromHardwareVersionVmAsync(HardwareVersionVm hardwareVersionVm);
    Task<HardwareVersionInsertVm> HardwareVersionInsertVmFromHardwareVersionVmAsync(HardwareVersionVm hardwareVersionVm);
    Task<HardwareVersion> HardwareVersionFromHardwareVersionEditVmAsync(HardwareVersionEditVm hardwareVersionEditVm);
    Task<HardwareVersion> HardwareVersionFromHardwareVersionInsertVmAsync(HardwareVersionInsertVm hardwareVersionInsertVm);
    Task<LoadVm> LoadVmFromLoadAsync(Load load);
    Task<Load> LoadFromLoadVm(LoadVm loadVm);
    Task<Load> LoadFromLoadInsertVm(LoadInsertVm loadInsertVm);
    Task<SoftwareSystem> SoftwareSystemFromSoftwareSystemVmAsync(SoftwareSystemVm softwareSystemVm);
    Task<SoftwareSystem> SoftwareSystemFromSoftwareSystemInsertVmAsync(SoftwareSystemInsertVm softwareSystemInsertVm);
    Task<SoftwareSystemVm> SoftwareSystemVmFromSoftwareSystemAsync(SoftwareSystem softwareSystem);
    Task<SoftwareVersionVm> SoftwareVersionVmFromSoftwareVersionsAsync(SoftwareVersion softwareVersion);
    Task<SoftwareVersion> SoftwareVersionFromSoftwareVersionsInsertVmAsync(SoftwareVersionInsertVm softwareVersionInsertVm);
    Task<SoftwareVersion> SoftwareVersionFromSoftwareVersionVmAsync(SoftwareVersionVm softwareVersionVm);

    Task<IEnumerable<DeviceVm>> DeviceVmsFromDevicesAsync(IEnumerable<Device> devices);
    Task<IEnumerable<MaintainerVm>> MaintainerVmsFromMaintainersAsync(IEnumerable<Maintainer> maintainers);
    Task<IEnumerable<DeviceTypeVm>> DeviceTypeVmsFromDeviceTypesAsync(IEnumerable<DeviceType> deviceTypes);
    Task<IEnumerable<HardwareConfigVm>> HardwareConfigVmsFromHardwareConfigsAsync(IEnumerable<HardwareConfig> hardwareConfigs);
    Task<IEnumerable<HardwareSystemVm>> HardwareSystemVmsFromHardwareSystemsAsync(IEnumerable<HardwareSystem> hardwareSystems);
    Task<IEnumerable<HardwareVersionVm>> HardwareVersionVmsFromHardwareVersionsAsync(IEnumerable<HardwareVersion> hardwareVersions);
    Task<IEnumerable<SoftwareVersionVm>> SoftwareVersionVmsFromSoftwareVersionsAsync(IEnumerable<SoftwareVersion> softwareVersions);
    Task<IEnumerable<SoftwareSystemVm>> SoftwareSystemVmsFromSoftwareSystemsAsync(IEnumerable<SoftwareSystem> softwareSystems);
    Task<IEnumerable<VersionsLoadVm>> VersionsLoadVmsFromVersionsLoadAsync(IEnumerable<VersionsLoad> versionsLoads);
    Task<IEnumerable<LoadVm>> LoadVmsFromLoads(IEnumerable<Load> loads);
}
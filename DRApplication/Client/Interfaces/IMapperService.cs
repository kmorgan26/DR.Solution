using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface IMapperService
{

    #region --- async Platform Maps---
    
    Task<DeviceVm> DeviceVmFromDeviceAsync(Device device);
    Task<DeviceTypeVm> DeviceTypeVmFromDeviceTypeAsync(DeviceType deviceType);

    #endregion

    #region --- Platform Maps ---
    CurrentLoadEditVm CurrentLoadEditVmFromCurrentLoadVm(CurrentLoadVm currentLoadVm);
    CurrentLoad CurrentLoadFromCurrentLoadEditVm(CurrentLoadEditVm currentLoadEditVm);
    Device DeviceFromDeviceVm(DeviceVm deviceVm);
    Device DeviceFromDeviceInsertVm(DeviceInsertVm deviceInsertVm);
    Device DeviceFromDeviceEditVm(DeviceEditVm deviceEditVm);
    DeviceEditVm DeviceEditVmFromDevice(Device device);
    DeviceEditVm DeviceEditVmFromDeviceVm(DeviceVm deviceVm);
    DeviceType DeviceTypeFromDeviceTypeEditVm(DeviceTypeEditVm deviceTypeEditVm);
    DeviceType DeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm);
    DeviceTypeEditVm DeviceTypeEditVmFromDeviceType(DeviceType deviceType);
    DeviceTypeEditVm DeviceTypeEditVmFromDeviceTypeVm(DeviceTypeVm deviceTypeVm);
    DeviceTypeInsertVm DeviceTypeInsertVmFromDeviceTypeVm(DeviceTypeVm deviceTypeVm);
    Maintainer MaintainerFromMaintainerEditVm(MaintainerEditVm maintainerEditVm);
    MaintainerVm MaintainerVmFromMaintainer(Maintainer maintainer);
    MaintainerEditVm MaintainerEditVmFromMaintainer(Maintainer maintainer);

    #endregion

    #region --- Platform Collection Maps ---

    Task<IEnumerable<DeviceVm>> DeviceVmsFromDevicesAsync(IEnumerable<Device> devices);
    Task<IEnumerable<DeviceTypeVm>> DeviceTypeVmsFromDeviceTypesAsync(IEnumerable<DeviceType> deviceTypes);
    IEnumerable<MaintainerVm> MaintainerVmsFromMaintainersAsync(IEnumerable<Maintainer> maintainers);

    #endregion


    Task<HardwareSystemVm> HardwareSystemVmFromHardwareSystemAsync(HardwareSystem hardwareSystem);
    Task<HardwareSystemEditVm> HardwareSystemEditVmFromHardwareSystemAsync(HardwareSystem hardwareSystem);
    Task<HardwareSystem> HardwareSystemFromHardwareSystemVmAsync(HardwareSystemVm hardwareSystemVm);
    Task<HardwareSystem> HardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm);
    Task<HardwareSystem> HardwareSystemFromHardwareSystemEditVm(HardwareSystemEditVm hardwareSystemEditVm);
    Task<HardwareConfigVm> HardwareConfigVmFromHardwareConfigAsync(HardwareConfig hardwareConfig);
    Task<HardwareConfigEditVm> HardwareConfigEditVmFromHardwareConfigVmAsync(HardwareConfigVm hardwareConfigVm);
    Task<HardwareConfig> HardwareConfigFromHardwareConfigInsertVmAsync(HardwareConfigInsertVm hardwareConfigInsertVm);
    Task<HardwareConfig> HardwareConfigFromHardwareConfigEditVmAsync(HardwareConfigEditVm hardwareConfigEditVm);
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

    Task<IEnumerable<HardwareConfigVm>> HardwareConfigVmsFromHardwareConfigsAsync(IEnumerable<HardwareConfig> hardwareConfigs);
    Task<IEnumerable<HardwareSystemVm>> HardwareSystemVmsFromHardwareSystemsAsync(IEnumerable<HardwareSystem> hardwareSystems);
    Task<IEnumerable<HardwareVersionVm>> HardwareVersionVmsFromHardwareVersionsAsync(IEnumerable<HardwareVersion> hardwareVersions);
    Task<IEnumerable<SoftwareVersionVm>> SoftwareVersionVmsFromSoftwareVersionsAsync(IEnumerable<SoftwareVersion> softwareVersions);
    Task<IEnumerable<SoftwareSystemVm>> SoftwareSystemVmsFromSoftwareSystemsAsync(IEnumerable<SoftwareSystem> softwareSystems);
    Task<IEnumerable<VersionsLoadVm>> VersionsLoadVmsFromVersionsLoadAsync(IEnumerable<VersionsLoad> versionsLoads);
    Task<IEnumerable<LoadVm>> LoadVmsFromLoads(IEnumerable<Load> loads);
}
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
    Task<IEnumerable<DeviceVm>> DeviceVmsFromDevicesAsync(IEnumerable<Device> devices);
    Task<IEnumerable<DeviceTypeVm>> DeviceTypeVmsFromDeviceTypesAsync(IEnumerable<DeviceType> deviceTypes);
    IEnumerable<MaintainerVm> MaintainerVmsFromMaintainers(IEnumerable<Maintainer> maintainers);

    #endregion

    #region --- Hardware Maps ---
    HardwareConfig HardwareConfigFromHardwareConfigInsertVm(HardwareConfigInsertVm hardwareConfigInsertVm);
    HardwareConfig HardwareConfigFromHardwareConfigEditVm(HardwareConfigEditVm hardwareConfigEditVm);
    HardwareConfigVm HardwareConfigVmFromHardwareConfig(HardwareConfig hardwareConfig);
    HardwareConfigEditVm HardwareConfigEditVmFromHardwareConfigVm(HardwareConfigVm hardwareConfigVm);
    HardwareSystem HardwareSystemFromHardwareSystemVm(HardwareSystemVm hardwareSystemVm);
    HardwareSystem HardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm);
    HardwareSystem HardwareSystemFromHardwareSystemEditVm(HardwareSystemEditVm hardwareSystemEditVm);
    HardwareSystemVm HardwareSystemVmFromHardwareSystem(HardwareSystem hardwareSystem);
    HardwareSystemEditVm HardwareSystemEditVmFromHardwareSystem(HardwareSystem hardwareSystem);
    HardwareVersion HardwareVersionFromHardwareVersionVm(HardwareVersionVm hardwareVersionVm);
    HardwareVersion HardwareVersionFromHardwareVersionInsertVm(HardwareVersionInsertVm hardwareVersionInsertVm);
    HardwareVersion HardwareVersionFromHardwareVersionEditVm(HardwareVersionEditVm hardwareVersionEditVm);
    HardwareVersionVm HardwareVersionVmFromHardwareVersion(HardwareVersion hardwareVersion);
    HardwareVersionInsertVm HardwareVersionInsertVmFromHardwareVersionVm(HardwareVersionVm hardwareVersionVm);
    HardwareVersionEditVm HardwareVersionEditVmFromHardwareVersion(HardwareVersion hardwareVersion);
    HardwareVersionEditVm HardwareVersionEditVmFromHardwareVersionVm(HardwareVersionVm hardwareVersionVm);
    IEnumerable<HardwareVersionVm> HardwareVersionVmsFromHardwareVersions(IEnumerable<HardwareVersion> hardwareVersions);
    IEnumerable<HardwareConfigVm> HardwareConfigVmsFromHardwareConfigs(IEnumerable<HardwareConfig> hardwareConfigs);
    IEnumerable<HardwareSystemVm> HardwareSystemVmsFromHardwareSystems(IEnumerable<HardwareSystem> hardwareSystems);

    #endregion

    #region --- async Software Maps ---
    Task<SoftwareSystemVm> SoftwareSystemVmFromSoftwareSystemAsync(SoftwareSystem softwareSystem);
    Task<IEnumerable<SoftwareSystemVm>> SoftwareSystemVmsFromSoftwareSystemsAsync(IEnumerable<SoftwareSystem> softwareSystems);

    #endregion

    #region --- Software Maps ---

    SoftwareSystem SoftwareSystemFromSoftwareSystemVm(SoftwareSystemVm softwareSystemVm);
    SoftwareSystem SoftwareSystemFromSoftwareSystemInsertVm(SoftwareSystemInsertVm softwareSystemInsertVm);
    SoftwareVersionVm SoftwareVersionVmFromSoftwareVersions(SoftwareVersion softwareVersion);
    SoftwareVersion SoftwareVersionFromSoftwareVersionsInsertVm(SoftwareVersionInsertVm softwareVersionInsertVm);
    SoftwareVersion SoftwareVersionFromSoftwareVersionVm(SoftwareVersionVm softwareVersionVm);
    IEnumerable<SoftwareVersionVm> SoftwareVersionVmsFromSoftwareVersionsAsync(IEnumerable<SoftwareVersion> softwareVersions);

    #endregion

    #region --- Load Maps ---
    
    LoadVm LoadVmFromLoad(Load load);
    Load LoadFromLoadVm(LoadVm loadVm);
    Load LoadFromLoadInsertVm(LoadInsertVm loadInsertVm);
    SpecificLoad SpecificLoadFromSpecificLoadVm(SpecificLoadVm specificLoadVm);
    IEnumerable<LoadVm> LoadVmsFromLoads(IEnumerable<Load> loads);


    #endregion

    Task<IEnumerable<VersionsLoadVm>> VersionsLoadVmsFromVersionsLoadAsync(IEnumerable<VersionsLoad> versionsLoads);
}
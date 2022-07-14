using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface IMapperService
{

    #region --- async Platform Maps---
    Task<DeviceVm> DeviceVmFromDeviceAsync(Device device);

    #endregion

    #region --- Platform Maps ---
    CurrentLoadEditVm CurrentLoadEditVmFromCurrentLoadVm(CurrentLoadVm currentLoadVm);
    CurrentLoad CurrentLoadFromCurrentLoadEditVm(CurrentLoadEditVm currentLoadEditVm);
    Device DeviceFromDeviceInsertVm(DeviceInsertVm deviceInsertVm);
    Device DeviceFromDeviceEditVm(DeviceEditVm deviceEditVm);
    DeviceEditVm DeviceEditVmFromDeviceVm(DeviceVm deviceVm);
    DeviceType DeviceTypeFromDeviceTypeEditVm(DeviceTypeEditVm deviceTypeEditVm);
    DeviceType DeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm);
    DeviceTypeEditVm DeviceTypeEditVmFromDeviceTypeVm(DeviceTypeVm deviceTypeVm);
    Maintainer MaintainerFromMaintainerEditVm(MaintainerEditVm maintainerEditVm);
    MaintainerVm MaintainerVmFromMaintainer(Maintainer maintainer);
    MaintainerEditVm MaintainerEditVmFromMaintainer(Maintainer maintainer);
    Task<IEnumerable<DeviceVm>> DeviceVmsFromDevicesAsync(IEnumerable<Device> devices);
    IEnumerable<MaintainerVm> MaintainerVmsFromMaintainers(IEnumerable<Maintainer> maintainers);

    #endregion

    #region --- Hardware Maps ---
    HardwareConfig HardwareConfigFromHardwareConfigInsertVm(HardwareConfigInsertVm hardwareConfigInsertVm);
    HardwareConfig HardwareConfigFromHardwareConfigEditVm(HardwareConfigEditVm hardwareConfigEditVm);
    HardwareConfigEditVm HardwareConfigEditVmFromHardwareConfig(HardwareConfig hardwareConfig);
    HardwareSystem HardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm);
    HardwareSystem HardwareSystemFromHardwareSystemEditVm(HardwareSystemEditVm hardwareSystemEditVm);
    HardwareSystemEditVm HardwareSystemEditVmFromHardwareSystem(HardwareSystem hardwareSystem);
    HardwareVersion HardwareVersionFromHardwareVersionInsertVm(HardwareVersionInsertVm hardwareVersionInsertVm);
    HardwareVersion HardwareVersionFromHardwareVersionEditVm(HardwareVersionEditVm hardwareVersionEditVm);
    HardwareVersionInsertVm HardwareVersionInsertVmFromHardwareVersionVm(HardwareVersionVm hardwareVersionVm);
    HardwareVersionEditVm HardwareVersionEditVmFromHardwareVersionVm(HardwareVersionVm hardwareVersionVm);
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


    #endregion

    Task<IEnumerable<VersionsLoadVm>> VersionsLoadVmsFromVersionsLoadAsync(IEnumerable<VersionsLoad> versionsLoads);
}
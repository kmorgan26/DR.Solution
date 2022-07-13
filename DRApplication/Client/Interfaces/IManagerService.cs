using DRApplication.Client.Services;

namespace DRApplication.Client.Interfaces;

public interface IManagerService
{
    DeviceTypeVmManager DeviceTypeVmManager();
    DeviceVmManager DeviceVmManager();
    CorrectiveActionManager CorrectiveActionManager();
    CurrentLoadVmManager CurrentLoadVmManager();
    CurrentLoadManager CurrentLoadManager();
    DeviceDiscoveredManager DeviceDiscoveredManager();
    DeviceManager DeviceManager();
    DeviceTypeManager DeviceTypeManager();
    DrManager DrManager();
    HardwareConfigManager HardwareConfigManager();
    HardwareSystemManager HardwareSystemManager();
    HardwareSystemVmManager HardwareSystemVmManager();
    HardwareVersionManager HardwareVersionManager();
    HardwareVersionVmManager HardwareVersionVmManager();
    IssueManager IssueManager();
    LoadManager LoadManager();
    LoadVmManager LoadVmManager();
    MaintainerManager MaintainerManager();
    MaintIssueManager MaintIssueManager();
    SoftwareSystemManager SoftwareSystemManager();
    SoftwareVersionManager SoftwareVersionManager();
    SpecificLoadManager SpecificLoadManager();
    SpecificLoadVmManager SpecificLoadVmManager();
    VersionsLoadManager VersionsLoadManager();
    VersionsLoadVmManager VersionsLoadVmManager();
}
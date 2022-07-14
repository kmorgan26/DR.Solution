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
    HardwareConfigVmManager HardwareConfigVmManager();
    HardwareSystemManager HardwareSystemManager();
    HardwareSystemVmManager HardwareSystemVmManager();
    HardwareVersionManager HardwareVersionManager();
    HardwareVersionVmManager HardwareVersionVmManager();
    IssueManager IssueManager();
    LoadManager LoadManager();
    LoadVmManager LoadVmManager();
    MaintainerManager MaintainerManager();
    MaintIssueManager MaintIssueManager();
    MaintIssueVmManager MaintIssueVmManager();
    SoftwareSystemManager SoftwareSystemManager();
    SoftwareSystemVmManager SoftwareSystemVmManager();
    SoftwareVersionManager SoftwareVersionManager();
    SoftwareVersionVmManager SoftwareVersionVmManager();
    SpecificLoadManager SpecificLoadManager();
    SpecificLoadVmManager SpecificLoadVmManager();
    VersionsLoadManager VersionsLoadManager();
    VersionsLoadVmManager VersionsLoadVmManager();
}
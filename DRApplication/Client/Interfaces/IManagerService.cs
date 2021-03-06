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
    HardwareVersionManager HardwareVersionManager();
    IssueManager IssueManager();
    LoadManager LoadManager();
    MaintainerManager MaintainerManager();
    MaintIssueManager MaintIssueManager();
    SoftwareSystemManager SoftwareSystemManager();
    SoftwareVersionManager SoftwareVersionManager();
    SpecificLoadManager SpecificLoadManager();
    VersionsLoadManager VersionsLoadManager();
}
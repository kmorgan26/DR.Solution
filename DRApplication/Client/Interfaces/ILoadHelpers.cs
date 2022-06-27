using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces
{
    public interface ILoadHelpers
    {
        Task<IEnumerable<SoftwareSystem>> GetSoftwareSystemFromSoftwareVersionAsync(IEnumerable<SoftwareVersion> softwareVersions);
        Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsFromVersionLoads(IEnumerable<VersionsLoad> versionsLoads);
        Task<IEnumerable<HardwareConfig>> GetHardwareConfigsFromSoftwareSystems(IEnumerable<SoftwareSystem> softwareSystems);
        Task<IEnumerable<VersionsLoad>> GetVersionsLoadsByLoadIdAsync(int id);
        Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsFromVersionsLoads(IEnumerable<VersionsLoad> versionsLoads);
    }
}
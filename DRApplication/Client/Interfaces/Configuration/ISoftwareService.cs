using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Interfaces
{
    public interface ISoftwareService
    {
        Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id);

        Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemVmsByHardwareConfigId(int id);

        Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id);

        Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsByLoadId(int id);

        Task<IEnumerable<VersionsLoad>> GetVersionLoadsByLoadId(int id);
    }
}
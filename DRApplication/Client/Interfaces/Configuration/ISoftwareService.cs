using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces
{
    public interface ISoftwareService
    {
        Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id);

        Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemVmsByHardwareConfigId(int id);

        Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id);

        Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsByLoadId(int id);

    }
}

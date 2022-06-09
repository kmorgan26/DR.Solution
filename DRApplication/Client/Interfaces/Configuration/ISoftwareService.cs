using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces
{
    public interface ISoftwareService
    {
        Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemsByHardwareConfigId(int id);

        Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionsBySoftwareSystemId(int id);

        Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id);
        
    }
}

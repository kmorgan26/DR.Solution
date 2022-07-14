using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces
{
    public interface ISoftwareService
    {
        Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id);
        
        Task<SoftwareVersionVm> GetSoftwareVersionVmById(int id);

        Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemVmsByHardwareConfigId(int id);

        Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id);
        
    }
}
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface ILoadBuilderService
{
    Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigsByDeviceTypeIdAsync(int i);

    Task<HardwareConfigVm> GetHardwareConfigVmById(int id);
    
    Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemsByHardwareConfigId(int id);

    Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id);

    Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionsBySoftwareSystemId(int id);

}

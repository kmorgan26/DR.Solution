using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface ILoadBuilderService
{
    Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigsByDeviceTypeIdAsync(int i);

    Task<HardwareConfigVm> GetHardwareConfigVmById(int id);
    
    Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemsByHardwareConfigIg(int id);

}

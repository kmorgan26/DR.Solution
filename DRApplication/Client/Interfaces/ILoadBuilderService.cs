using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface ILoadBuilderService
{
    Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigsByDeviceTypeIdAsync(int i);

    Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemsByHardwareConfigIg(int id);



}

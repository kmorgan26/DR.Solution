using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface IHardwareService
{
    Task<HardwareSystemVm> GetHardwareSystemVmById(int id);
    Task<HardwareConfigVm> GetHardwareConfigVmById(int id);
    Task<HardwareVersionVm> GetHardwareVersionVmById(int id);
    Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms();
    Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionVmsByHardwareSystemId(int id);
    Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int i);
}
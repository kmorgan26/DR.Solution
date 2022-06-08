using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface IHardwareService
{
    Task<HardwareSystemVm> GetHardwareSystemVmById(int id);

    Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms();

    Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionsByHardwareSystemId(int id);

    Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigsByDeviceTypeId(int id);

    Task<HardwareConfigVm> GetHardwareConfigVmById(int id);
}

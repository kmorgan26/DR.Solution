using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface IHardwareService
{
    Task<HardwareSystemVm> GetHardwareSystemVmById(int id);
    Task<HardwareSystemEditVm> GetHardwareSystemEditVmById(int id);
    Task<HardwareConfigVm> GetHardwareConfigVmById(int id);
    Task<IEnumerable<HardwareSystemVm>> GetHardwareSystemVms();
    Task<IEnumerable<HardwareVersionVm>> GetHardwareVersionVmsByHardwareSystemId(int id);
    Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int i);
    Task<bool> UpdateHardwareSystemFromHardwareSystemEditVm(HardwareSystemEditVm hardwareSystemEditVm);
    Task<int> InsertHardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm);
}
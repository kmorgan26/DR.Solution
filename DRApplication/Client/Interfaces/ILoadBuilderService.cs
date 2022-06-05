using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface ILoadBuilderService
{
    Task<IEnumerable<HardwareConfigVm>> GetHardwareConfigVmsByDeviceTypeIdAsync(int i);

    Task<HardwareConfigVm> GetHardwareConfigVmById(int id);
    
    Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemVmsByHardwareConfigId(int id);

    Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id);

    Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id);

    Task<IEnumerable<LoadVm>> GetLoadVmByDeviceTypeId(int id);

    Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsByLoadId(int id);

    Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id);
}
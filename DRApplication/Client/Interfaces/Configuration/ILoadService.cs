using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface ILoadService
{
    Task<IEnumerable<LoadVm>> GetLoadVmsByHardwareConfigId(int id);
    Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id);
    Task<IEnumerable<CurrentLoadVm>> GetCurrentLoadVmsByDeviceTypeId(int id);
    Task<IEnumerable<CurrentLoadVm>> MapCurrentLoadsToCurrentLoadVms(IEnumerable<CurrentLoad> currentLoads);
    Task<IEnumerable<SpecificLoadVm>> GetSpecificLoadVmsByDeviceTypeId(int id);
    Task<CurrentLoadVm> MapCurrentLoadToCurrentLoadVm(CurrentLoad currentLoad);
    Task<CurrentLoadVm> GetCurrentLoadVmById(int id);
    Task<CurrentLoad> GetCurrentLoadFromCurrentLoadVm(CurrentLoadVm currentLoadVm);
    Task<SpecificLoad> GetSpecificLoadFromSpecificLoadVm(SpecificLoadVm specificLoadVm);
    Task<SpecificLoadVm> GetSpecificLoadVmById(int id);
    Task<LoadVm> GetLoadVmById(int id);
    Task AddSoftwareVersionToLoad();
}
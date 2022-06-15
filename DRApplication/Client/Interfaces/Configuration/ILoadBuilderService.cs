using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Interfaces;

public interface ILoadBuilderService
{
    Task<IEnumerable<LoadVm>> GetLoadVmsByHardwareConfigId(int id);
    Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id);
    Task<IEnumerable<CurrentLoadVm>> GetCurrentLoadVmByDeviceTypeId(int id);
    Task<IEnumerable<CurrentLoadVm>> MapCurrentLoadsToCurrentLoadVms(IEnumerable<CurrentLoad> currentLoads);
    Task<CurrentLoadVm> MapCurrentLoadToCurrentLoadVm(CurrentLoad currentLoad);
    Task<CurrentLoadVm> GetCurrentLoadVmById(int id);
    Task<CurrentLoad> GetCurrentLoadFromCurrentLoadVm(CurrentLoadVm currentLoadVm);
    Task<LoadVm> GetLoadVmById(int id);
    Task AddSoftwareVersionToLoad();
}
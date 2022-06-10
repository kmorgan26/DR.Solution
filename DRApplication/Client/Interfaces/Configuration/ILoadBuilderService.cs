using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface ILoadBuilderService
{
    Task<IEnumerable<LoadVm>> GetLoadVmByDeviceTypeId(int id);
    
    Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id);

    Task AddSoftwareVersionToLoad();
}
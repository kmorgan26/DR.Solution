using DRApplication.Shared.Enums;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

public interface IGenericListService
{
    Task<IEnumerable<GenericListVm>> GetGenericListVmsFromPlatformListName(PlatformListName listType);
}
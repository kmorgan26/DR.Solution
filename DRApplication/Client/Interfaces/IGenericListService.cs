using DRApplication.Client.Enums;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces
{
    public interface IGenericListService
    {
        Task<IEnumerable<GenericListVm>> GetGenericListVmsAsync(PlatformListType listType);
    }
}

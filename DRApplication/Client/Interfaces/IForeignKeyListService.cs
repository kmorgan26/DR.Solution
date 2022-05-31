using DRApplication.Client.ViewModels;
using DRApplication.Shared.Requests;

namespace DRApplication.Client.Interfaces;

public interface IForeignKeyListService
{
    Task<IEnumerable<ForeignKeyListVm>> GetForeignKeyListVmsFromPlatformListName(ForeignKeyListRequest request);
}
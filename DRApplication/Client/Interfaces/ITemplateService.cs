using DRApplication.Client.Requests;

namespace DRApplication.Client.Interfaces
{
    public interface ITemplateService
    {
        Task<object> GetTableRequestByViewModelName(string viewModelName);

    }
}

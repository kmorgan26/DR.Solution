using DRApplication.Client.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Client.Interfaces
{
    public interface ITemplateService
    {
        Task<object> GetTableRequestByViewModelName(string viewModelName);

    }
}

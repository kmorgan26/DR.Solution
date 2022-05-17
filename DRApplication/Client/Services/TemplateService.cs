using DRApplication.Client.Interfaces;
using DRApplication.Client.Requests;
using DRApplication.Client.ViewModels.Platform;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Client.Services
{
    public class TemplateService : ITemplateService
    {
        public Task<object> GetTableRequestByViewModelName(string viewModelName)
        {
            throw new NotImplementedException();
        }
        
    }
}

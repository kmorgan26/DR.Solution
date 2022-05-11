using DRApplication.Client.Controls.Generic;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.DeviceModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class DeviceComponent
    {
        [CascadingParameter]
        public AppStateComponent? appStateComponent { get; set; }

        IEnumerable<DeviceVm> _deviceVms;
        
        private PagedResponse<Device> _pagedResponse = new();

        private async Task SelectedPage(int page)
        {
            if (appStateComponent is not null)
            {
                appStateComponent.PaginationFilter.PageNumber = page;
                await LoadData();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }
        private async Task LoadData()
        {
            if(appStateComponent is not null)
            {
                var queryFilter = new QueryFilter<Device>();
                _pagedResponse = await manager.GetAsync(queryFilter);
                

                _deviceVms = Mapping.Mapper.Map<List<DeviceVm>>(_pagedResponse.Data);
            }
        }
    }
}
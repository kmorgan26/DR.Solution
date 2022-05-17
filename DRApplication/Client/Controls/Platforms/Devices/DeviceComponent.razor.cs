using DRApplication.Client.Controls.Generic;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.DeviceModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DRApplication.Client.Controls.Platforms
{
    //public partial class DeviceComponent
    //{
    //    private MudTable<DeviceVm> _table;

    //    IEnumerable<DeviceVm> _deviceVms;

    //    private PagedResponse<Device> _pagedResponse = new();
    //    private PaginationFilter _paginationFilter = new();

    //    private async Task SelectedPage(int page)
    //    {
    //        if (_pagedResponse is not null)
    //        {
    //            _pagedResponse.PageNumber = page;
    //            await LoadData();
    //        }
    //    }
    //    private async Task Pageup()
    //    {
    //        if (_pagedResponse is not null)
    //        {
    //            _pagedResponse.PageNumber++;
    //            await LoadData();
    //        }

    //    }
    //    private async void PageChanged(int i)
    //    {
    //        if (_pagedResponse is not null)
    //        {
    //            _paginationFilter.PageNumber = i;
    //            await LoadData();
    //        }
    //    }
    //    protected override async Task OnInitializedAsync()
    //    {
    //        await LoadData();
    //    }
    //    private async Task LoadData()
    //    {
    //        var queryFilter = new QueryFilter<Device>();
    //        queryFilter.PaginationFilter = _paginationFilter;

    //        _pagedResponse = await manager.GetAsync(queryFilter);


    //        _deviceVms = Mapping.Mapper.Map<List<DeviceVm>>(_pagedResponse.Data);
    //        StateHasChanged();
    //    }
    //}
}
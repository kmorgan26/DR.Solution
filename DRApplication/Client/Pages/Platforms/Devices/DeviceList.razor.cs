using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Filters;
using Microsoft.AspNetCore.Components;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Pages;

public partial class DeviceList
{
    [Parameter]
    public int DeviceTypeId { get; set; }

    [Inject]
    public DeviceManager? DeviceManager { get; set; }

    IEnumerable<DeviceVm>? Devices;

    protected override async Task OnInitializedAsync()
    {
        if(DeviceManager is not null)
        {
            var filterProperty = new FilterProperty() {  Name ="DeviceTypeId", Operator=FilterQueryOperator.Equals, Value=DeviceTypeId.ToString() };
            var filter = new QueryFilter<Device>();
            filter.PaginationFilter = null;
            filter.FilterProperties.Add(filterProperty);

            var response = await DeviceManager.GetAsync(filter);
            var items = response.Data;
            Devices = Mapping.Mapper.Map<IEnumerable<DeviceVm>>(items);
        }
    }
}
using DRApplication.Client.Services;
using DRApplication.Client.Services.Platforms;
using DRApplication.Client.ViewModels.Platform;
using Microsoft.AspNetCore.Components;
namespace DRApplication.Client.Pages;

public partial class Index
{
    IEnumerable<DeviceTypeVm>? items;

    [Inject]
    public DeviceTypeManager? DeviceTypeManager { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        if(DeviceTypeManager is not null)
        {
            var deviceTypes = await DeviceTypeManager.GetAllAsync();
            items = Mapping.Mapper.Map<IEnumerable<DeviceTypeVm>>(deviceTypes);
        }        
    }
}
using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Pages;

public partial class DeviceDetails
{
    [Parameter]
    public int DeviceId { get; set; }

    [Inject]
    public DeviceManager? manager { get; set; }

    DeviceVm? DeviceVm;
    protected override async Task OnInitializedAsync()
    {
        if(manager is not null)
        {
            var device = await manager.GetByIdAsync(DeviceId);
            DeviceVm = Mapping.Mapper.Map<DeviceVm>(device);
        }        
    }
}
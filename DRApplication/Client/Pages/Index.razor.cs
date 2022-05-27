using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
namespace DRApplication.Client.Pages;

public partial class Index
{
    IEnumerable<DeviceTypeVm>? items;
    bool _isBusy;
    protected override async Task OnInitializedAsync()
    {
        _isBusy = true;
        var deviceTypeVms = await PlatformService.GetDeviceTypeVmsAsync();
        items = Mapping.Mapper.Map<IEnumerable<DeviceTypeVm>>(deviceTypeVms);
        _isBusy = false;
    }
}
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.DeviceModels;
using Microsoft.AspNetCore.Components;
namespace DRApplication.Client.Controls;

public partial class DeviceTypeTable
{
    bool _isBusy;

    [Parameter]
    public IEnumerable<DeviceTypeVm>? DeviceTypeVms { get; set; }

    private List<MaintainerVm> _maintainers = new();

    private async Task UpdateRowItem(object e)
    {
        var viewModel = (DeviceTypeVm)e;
        var model = Mapping.Mapper.Map<DeviceType>(viewModel);
        await _db.UpdateAsync(model);
    }

    protected override async Task OnInitializedAsync()
    {
        _isBusy = true;
        DeviceTypeVms = await PlatformService.GetDeviceTypeVmsAsync();

        var list = await PlatformService.GetMaintainerVmsAsync();
        _maintainers = list.ToList();
        _isBusy = false;
    }
}

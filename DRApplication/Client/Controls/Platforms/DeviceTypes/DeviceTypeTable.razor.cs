using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Models.DeviceModels;
using Microsoft.AspNetCore.Components;
namespace DRApplication.Client.Controls.Platforms;

public partial class DeviceTypeTable
{
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
        var list = await PlatformService.GetMaintainerVmsAsync();
        _maintainers = list.ToList();
    }
}

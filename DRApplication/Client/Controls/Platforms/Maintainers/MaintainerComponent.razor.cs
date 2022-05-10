using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
namespace DRApplication.Client.Controls.Platforms;
public partial class MaintainerComponent
{
    List<MaintainerVm> _maintainerVms = new();
    protected override async Task OnInitializedAsync()
    {
        var items = await manager.GetAllAsync();
        _maintainerVms = Mapping.Mapper.Map<List<MaintainerVm>>(items);
    }
}

using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.MaintainerViewModels;

namespace DRApplication.Client.Controls.Platforms.Maintainers;

public partial class MaintainerComponent
{
    List<MaintainerVm> _maintainerVms = new();
    protected override async Task OnInitializedAsync()
    {
        var items = await manager.GetAllAsync();
        _maintainerVms = Mapping.Mapper.Map<List<MaintainerVm>>(items);
    }
}

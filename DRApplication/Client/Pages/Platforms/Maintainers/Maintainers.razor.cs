using DRApplication.Client.Services;
using DRApplication.Client.Services.Platforms;
using DRApplication.Client.ViewModels.Platform;
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Pages.Platforms;

public partial class Maintainers
{
    private IEnumerable<MaintainerVm> _maintainerVms;

    protected override async Task OnInitializedAsync()
    {
        var items = await _manager.GetAllAsync();
        _maintainerVms = Mapping.Mapper.Map<List<MaintainerVm>>(items);
    }
}
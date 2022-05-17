using DRApplication.Client.ViewModels.Platform;
using DRApplication.Client.Requests;
namespace DRApplication.Client.Pages.Platforms;
public partial class Maintainers
{
    bool _isBusy;
    public IEnumerable<MaintainerVm> _viewModels { get; set; }

    private TableRequest<MaintainerVm> _tableRequest()
    {
        return new TableRequest<MaintainerVm>()
        { 
            Data = _viewModels, 
            UrlSegment = "maintainer/edit"
        };
    }

    protected override async Task OnInitializedAsync()
    {
        _isBusy = true;
        _viewModels = await _service.GetMaintainerVmsAsync();
        _isBusy = false;
    }
}
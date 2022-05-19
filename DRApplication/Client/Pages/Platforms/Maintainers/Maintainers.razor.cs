using DRApplication.Client.ViewModels.Platform;
using DRApplication.Client.Requests;
using DRApplication.Client.Services;
using DRApplication.Client.Business_Models;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Pages.Platforms;
public partial class Maintainers
{
    bool _isBusy;
    public IEnumerable<MaintainerVm> _viewModels { get; set; }
    

    protected override async Task OnInitializedAsync()
    {
        _isBusy = true;
        var models = await _db.GetAllAsync();
        _viewModels = Mapping.Mapper.Map<IEnumerable<MaintainerVm>>(models);
        _isBusy = false;
    }
    private void RowEditPreview()
    {

    }
    
    private List<string> _editEvents = new();

    private void SaveChanges(MaintainerVm maintainerVm)
    {
        var maintainer = Mapping.Mapper.Map<Maintainer>(maintainerVm);
        _db.UpdateAsync(maintainer);
    }

}
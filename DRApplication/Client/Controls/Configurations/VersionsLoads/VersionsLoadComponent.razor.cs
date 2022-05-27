using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls
{
    public partial class VersionsLoadComponent
    {
        IEnumerable<VersionsLoadVm> _versionsLoadVms;
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _versionsLoadVms = Mapping.Mapper.Map<List<VersionsLoadVm>>(items);
        }
    }
}
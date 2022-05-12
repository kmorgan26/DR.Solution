using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;

namespace DRApplication.Client.Controls.Configurations
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
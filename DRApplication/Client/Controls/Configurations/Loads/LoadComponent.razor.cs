using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class LoadComponent
    {
        IEnumerable<LoadVm> _loadVms;
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _loadVms = Mapping.Mapper.Map<List<LoadVm>>(items);
        }
    }
}
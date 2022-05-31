using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls
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
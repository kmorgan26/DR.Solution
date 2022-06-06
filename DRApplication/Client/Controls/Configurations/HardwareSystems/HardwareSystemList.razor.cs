using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls
{
    public partial class HardwareSystemList
    {
        List<HardwareSystemVm> _hardwareSystemVms = new();
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _hardwareSystemVms = Mapping.Mapper.Map<List<HardwareSystemVm>>(items);
        }
    }
}
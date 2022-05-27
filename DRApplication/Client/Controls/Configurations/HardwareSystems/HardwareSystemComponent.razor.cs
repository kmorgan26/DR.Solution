using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareSystemComponent
    {
        List<HardwareSystemVm> _hardwareSystemVms = new();
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _hardwareSystemVms = Mapping.Mapper.Map<List<HardwareSystemVm>>(items);
        }
    }
}
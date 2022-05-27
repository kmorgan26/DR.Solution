using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareVersionsConfigComponent
    {
        IEnumerable<HardwareVersionsConfigVm> _hardwareVersionsConfigVms;
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _hardwareVersionsConfigVms = Mapping.Mapper.Map<List<HardwareVersionsConfigVm>>(items);
        }
    }
}
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareConfigComponent
    {
        IEnumerable<HardwareConfigVm> _hardwareConfigVms;
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _hardwareConfigVms = Mapping.Mapper.Map<List<HardwareConfigVm>>(items);
        }
    }
}
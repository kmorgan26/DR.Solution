using DRApplication.Client.ViewModels;
using DRApplication.Client.Services;

namespace DRApplication.Client.Controls
{
    public partial class HardwareSystemList
    {
        bool _isBusy;
        async Task SetHardwareSystems()
        {
            var items = await manager.GetAllAsync();
            var vms = Mapping.Mapper.Map<List<HardwareSystemVm>>(items);
            AppState.UpdateHardwareSystemVms(this, vms);
        }

        protected override async Task OnInitializedAsync()
        {
            _isBusy = true;
            await SetHardwareSystems();
            _isBusy = false;
        }
    }
}
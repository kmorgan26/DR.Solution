using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareVersionComponent
    {
        IEnumerable<HardwareVersionVm> _hardwareVersionVms;
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _hardwareVersionVms = Mapping.Mapper.Map<List<HardwareVersionVm>>(items);
        }
    }
}
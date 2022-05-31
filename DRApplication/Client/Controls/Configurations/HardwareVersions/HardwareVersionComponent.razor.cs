using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls
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
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class DeviceComponent
    {
        IEnumerable<DeviceVm> _deviceVms;
        protected override async Task OnInitializedAsync()
        {
            var devices = await manager.GetAllAsync();
            _deviceVms = Mapping.Mapper.Map<List<DeviceVm>>(devices);
        }
    }
}
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class DeviceComponent
    {
        IEnumerable<DeviceVm> _deviceVms;
        protected override async Task OnInitializedAsync()
        {
            var queryFilter = new QueryFilter<Device>();
            var devices = await manager.GetAsync(queryFilter);
            //var devices = await manager.GetAllAsync();
            _deviceVms = Mapping.Mapper.Map<List<DeviceVm>>(devices);
        }
    }
}
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Helpers;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class DeviceTypeComponent
    {
        IEnumerable<DeviceTypeVm> _deviceTypeVms;
        List<MaintainerVm> _maintainerVms = new();
        MappingHelper _mappingHelper = new();
        protected override async Task OnInitializedAsync()
        {
            var deviceTypes = await manager.GetAllAsync();
            _deviceTypeVms = Mapping.Mapper.Map<List<DeviceTypeVm>>(deviceTypes);
        }
    }
}
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Controls
{
    public partial class DeviceTypeLabel
    {
        [Parameter]
        public int DeviceTypeId { get; set; }

        string _deviceTypeName { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var deviceTypes = await manager.GetByIdAsync(DeviceTypeId);
            _deviceTypeName = deviceTypes.Name;
        }
    }
}
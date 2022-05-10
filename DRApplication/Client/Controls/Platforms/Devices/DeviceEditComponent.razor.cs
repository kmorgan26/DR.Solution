using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class DeviceEditComponent
    {
        [Parameter]
        public int DeviceId { get; set; }

        public DeviceEditVm DeviceEditVm { get; set; } = new();
        void UpdateDeviceType(int? id)
        {
            DeviceEditVm.DeviceTypeId = Convert.ToInt32(id);
        }

        protected async Task UpdateDevice()
        {
            var device = Mapping.Mapper.Map<Device>(DeviceEditVm);
            await manager.UpdateAsync(device);
            navigation.NavigateTo("/devices");
        }

        protected override async Task OnInitializedAsync()
        {
            var devices = await manager.GetByIdAsync(DeviceId);
            DeviceEditVm = Mapping.Mapper.Map<DeviceEditVm>(devices);
        }
    }
}
using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class DeviceTypeEditComponent
    {
        [Parameter]
        public int DeviceTypeId { get; set; }

        public DeviceTypeEditVm DeviceTypeEditVm { get; set; } = new();
        void UpdateMaintainer(int? id)
        {
            DeviceTypeEditVm.MaintainerId = Convert.ToInt32(id);
        }

        protected async Task UpdateDeviceType()
        {
            var deviceType = Mapping.Mapper.Map<DeviceType>(DeviceTypeEditVm);
            await manager.UpdateAsync(deviceType);
            navigation.NavigateTo("/deviceTypes");
        }

        protected override async Task OnInitializedAsync()
        {
            var deviceTypes = await manager.GetByIdAsync(DeviceTypeId);
            DeviceTypeEditVm = Mapping.Mapper.Map<DeviceTypeEditVm>(deviceTypes);
        }
    }
}
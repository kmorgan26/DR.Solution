using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareConfigEditComponent
    {
        [Parameter]
        public int HardwareConfigId { get; set; }

        public HardwareConfigEditVm HardwareConfigEditVm { get; set; } = new();
        void UpdateDeviceType(int? id)
        {
            HardwareConfigEditVm.DeviceTypeId = Convert.ToInt32(id);
        }

        protected async Task UpdateHarwareConfig()
        {
            var hardwareConfig = Mapping.Mapper.Map<HardwareConfig>(HardwareConfigEditVm);
            await manager.UpdateAsync(hardwareConfig);
            navigation.NavigateTo("/hardwareconfig");
        }

        protected override async Task OnInitializedAsync()
        {
            var hardwareConfig = await manager.GetByIdAsync(HardwareConfigId);
            HardwareConfigEditVm = Mapping.Mapper.Map<HardwareConfigEditVm>(hardwareConfig);
        }
    }
}
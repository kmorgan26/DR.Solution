using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareVersionsConfigEditComponent
    {
        [Parameter]
        public int HardwareVersionsConfigId { get; set; }

        public HardwareVersionsConfigEditVm HardwareVersionsConfigEditVm { get; set; } = new();
        void UpdateHardwareVersion(int? id)
        {
            HardwareVersionsConfigEditVm.HardwareVersionId = Convert.ToInt32(id);
        }

        void UpdateHardwareConfig(int? id)
        {
            HardwareVersionsConfigEditVm.HardwareConfigId = Convert.ToInt32(id);
        }

        protected async Task UpdateHardwareVersionsConfig()
        {
            var hardwareVersion = Mapping.Mapper.Map<HardwareVersionsConfig>(HardwareVersionsConfigEditVm);
            await manager.UpdateAsync(hardwareVersion);
            navigation.NavigateTo("/hardwareversionsconfig");
        }

        protected override async Task OnInitializedAsync()
        {
            var hardwareVersion = await manager.GetByIdAsync(HardwareVersionsConfigId);
            HardwareVersionsConfigEditVm = Mapping.Mapper.Map<HardwareVersionsConfigEditVm>(hardwareVersion);
        }
    }
}
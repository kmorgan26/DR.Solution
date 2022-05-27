using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareVersionEditComponent
    {
        [Parameter]
        public int HardwareVersionId { get; set; }

        public HardwareVersionEditVm HardwareVersionEditVm { get; set; } = new();
        void UpdateHardwareSystem(int? id)
        {
            HardwareVersionEditVm.HardwareSystemId = Convert.ToInt32(id);
        }

        protected async Task UpdateHardwareVersion()
        {
            var hardwareVersion = Mapping.Mapper.Map<HardwareVersion>(HardwareVersionEditVm);
            await manager.UpdateAsync(hardwareVersion);
            navigation.NavigateTo("/hardwareversion");
        }

        protected override async Task OnInitializedAsync()
        {
            var hardwareVersion = await manager.GetByIdAsync(HardwareVersionId);
            HardwareVersionEditVm = Mapping.Mapper.Map<HardwareVersionEditVm>(hardwareVersion);
        }
    }
}
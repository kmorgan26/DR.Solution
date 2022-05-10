using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareSystemEditComponent
    {
        [Parameter]
        public int HardwareSystemId { get; set; }

        public HardwareSystemEditVm HardwareSystemEditVm { get; set; } = new();
        protected async Task UpdateHardwareSystem()
        {
            var hardwareSystem = Mapping.Mapper.Map<HardwareSystem>(HardwareSystemEditVm);
            await manager.UpdateAsync(hardwareSystem);
            navigation.NavigateTo("/hardwaresystem");
        }

        protected override async Task OnInitializedAsync()
        {
            var hardwareSystem = await manager.GetByIdAsync(HardwareSystemId);
            HardwareSystemEditVm = Mapping.Mapper.Map<HardwareSystemEditVm>(hardwareSystem);
        }
    }
}
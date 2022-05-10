using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class SoftwareSystemEditComponent
    {
        [Parameter]
        public int SoftwareSystemId { get; set; }

        private SoftwareSystemEditVm _softwareSystemEditVm { get; set; } = new();
        void UpdateConfig(int? id)
        {
            _softwareSystemEditVm.HardwareConfigId = Convert.ToInt32(id);
        }

        protected async Task UpdateSoftwareSystem()
        {
            var softwareSystem = Mapping.Mapper.Map<SoftwareSystem>(_softwareSystemEditVm);
            await manager.UpdateAsync(softwareSystem);
            navigation.NavigateTo("/softwaresystem");
        }

        protected override async Task OnInitializedAsync()
        {
            var softwareSystem = await manager.GetByIdAsync(SoftwareSystemId);
            _softwareSystemEditVm = Mapping.Mapper.Map<SoftwareSystemEditVm>(softwareSystem);
        }
    }
}
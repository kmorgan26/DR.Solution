using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls
{
    public partial class SoftwareVersionEditComponent
    {
        [Parameter]
        public int SoftwareVersionId { get; set; }

        public SoftwareVersionEditVm SoftwareVersionEditVm { get; set; } = new();
        void UpdateSoftwareSystem(int? id)
        {
            SoftwareVersionEditVm.SoftwareSystemId = Convert.ToInt32(id);
        }

        protected async Task UpdateSoftwareVersion()
        {
            var softwareVersion = Mapping.Mapper.Map<SoftwareVersion>(SoftwareVersionEditVm);
            await manager.UpdateAsync(softwareVersion);
            navigation.NavigateTo("/softwareversion");
        }

        protected override async Task OnInitializedAsync()
        {
            var softwareVersion = await manager.GetByIdAsync(SoftwareVersionId);
            SoftwareVersionEditVm = Mapping.Mapper.Map<SoftwareVersionEditVm>(softwareVersion);
        }
    }
}
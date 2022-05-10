using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class MaintainerEditComponent
    {
        [Parameter]
        public int MaintainerId { get; set; }

        public MaintainerEditVm MaintainerEditVm { get; set; } = new();
        protected async Task UpdateMaintainer()
        {
            var maintainer = Mapping.Mapper.Map<Maintainer>(MaintainerEditVm);
            await manager.UpdateAsync(maintainer);
            navigation.NavigateTo("/maintainers");
        }

        protected override async Task OnInitializedAsync()
        {
            var maintainers = await manager.GetByIdAsync(MaintainerId);
            MaintainerEditVm = Mapping.Mapper.Map<MaintainerEditVm>(maintainers);
        }
    }
}
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class MaintainerLabel
    {
        [Parameter]
        public int MaintainerId { get; set; }

        string _maintainerName { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var maintainer = await manager.GetByIdAsync(MaintainerId);
            _maintainerName = maintainer.Name;
        }
    }
}
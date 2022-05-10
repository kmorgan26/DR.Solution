using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class SoftwareSystemLabel
    {
        [Parameter]
        public int SoftwareSystemId { get; set; }

        string _softwareSystemName { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var softwareSystems = await manager.GetByIdAsync(SoftwareSystemId);
            _softwareSystemName = softwareSystems.Name;
        }
    }
}
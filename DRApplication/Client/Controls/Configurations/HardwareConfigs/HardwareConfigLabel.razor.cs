using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Controls
{
    public partial class HardwareConfigLabel
    {
        [Parameter]
        public int HardwareConfigId { get; set; }

        string _hardwareConfigName { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var HardwareConfigs = await manager.GetByIdAsync(HardwareConfigId);
            _hardwareConfigName = HardwareConfigs.Name;
        }
    }
}
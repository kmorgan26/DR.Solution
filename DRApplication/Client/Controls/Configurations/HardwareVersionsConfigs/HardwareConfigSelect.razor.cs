using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.Controls.Generic;
using DRApplication.Client.ViewModels.Shared;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareConfigSelect
    {
        [Parameter]
        public EventCallback<int?> HardwareConfigIdChange { get; set; }

        [Parameter]
        public int? SelectedHardwareConfigId { get; set; }

        [CascadingParameter]
        public AppStateComponent? AppStateComponent { get; set; }

        private List<GenericListVm> _hardwareConfigVms = new();
        private async Task ChangeHardwareConfig(int? value)
        {
            if (AppStateComponent is not null)
            {
                SelectedHardwareConfigId = Convert.ToInt32(value);
                AppStateComponent.AppStateReset();
                await HardwareConfigIdChange.InvokeAsync(SelectedHardwareConfigId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var hardwareConfigs = await manager.GetAllAsync();
            _hardwareConfigVms = Mapping.Mapper.Map<List<GenericListVm>>(hardwareConfigs);
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                if (AppStateComponent is not null && AppStateComponent.HardwareConfigId is not null)
                {
                    await Task.Delay(0);
                    SelectedHardwareConfigId = AppStateComponent.HardwareConfigId != null ? AppStateComponent.HardwareConfigId : 0;
                }
            }
            catch
            {
            }
        }
    }
}
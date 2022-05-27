using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.Controls.Generic;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls
{
    public partial class HardwareSystemSelect
    {
        [Parameter]
        public EventCallback<int?> HardwareSystemIdChange { get; set; }

        [Parameter]
        public int? SelectedHardwareSystemId { get; set; }

        [CascadingParameter]
        public AppStateComponent? AppStateComponent { get; set; }

        private List<GenericListVm> _hardwareSystemVms = new();
        private async Task ChangeHardwareSystem(int? value)
        {
            if (AppStateComponent is not null)
            {
                SelectedHardwareSystemId = Convert.ToInt32(value);
                AppStateComponent.AppStateReset();
                await HardwareSystemIdChange.InvokeAsync(SelectedHardwareSystemId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var hardwareSystems = await manager.GetAllAsync();
            _hardwareSystemVms = Mapping.Mapper.Map<List<GenericListVm>>(hardwareSystems);
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                if (AppStateComponent is not null && AppStateComponent.HardwareSystemId is not null)
                {
                    await Task.Delay(0);
                    SelectedHardwareSystemId = AppStateComponent.HardwareSystemId != null ? AppStateComponent.HardwareSystemId : 0;
                }
            }
            catch
            {
            }
        }
    }
}
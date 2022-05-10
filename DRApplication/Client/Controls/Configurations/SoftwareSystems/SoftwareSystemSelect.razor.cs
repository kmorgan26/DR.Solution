using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.Controls.Generic;
using DRApplication.Client.ViewModels.Shared;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class SoftwareSystemSelect
    {
        [Parameter]
        public EventCallback<int?> SoftwareSystemIdChange { get; set; }

        [Parameter]
        public int? SelectedSoftwareSystemId { get; set; }

        [CascadingParameter]
        public AppStateComponent? AppStateComponent { get; set; }

        private List<GenericListVm> _softwareSystemVms = new();
        private async Task ChangeSoftwareSystem(int? value)
        {
            if (AppStateComponent is not null)
            {
                SelectedSoftwareSystemId = Convert.ToInt32(value);
                AppStateComponent.AppStateReset();
                await SoftwareSystemIdChange.InvokeAsync(SelectedSoftwareSystemId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var softwareSystems = await manager.GetAllAsync();
            _softwareSystemVms = Mapping.Mapper.Map<List<GenericListVm>>(softwareSystems);
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                if (AppStateComponent is not null && AppStateComponent.SoftwareSystemId is not null)
                {
                    await Task.Delay(0);
                    SelectedSoftwareSystemId = AppStateComponent.SoftwareSystemId != null ? AppStateComponent.SoftwareSystemId : 0;
                }
            }
            catch
            {
            }
        }
    }
}
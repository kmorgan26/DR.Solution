using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class MaintainerSelectComponent
    {
        [Parameter]
        public EventCallback<int?> MaintainerIdChange { get; set; }

        [Parameter]
        public int? SelectedMaintainerId { get; set; }

        [CascadingParameter]
        public AppStateComponent? AppStateComponent { get; set; }

        private List<GenericListVm> _maintainerVms = new();
        private async Task ChangeMaintainer(int? value)
        {
            if (AppStateComponent is not null)
            {
                SelectedMaintainerId = Convert.ToInt32(value);
                AppStateComponent.AppStateReset();
                await MaintainerIdChange.InvokeAsync(SelectedMaintainerId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var maintainers = await manager.GetAllAsync();
            _maintainerVms = Mapping.Mapper.Map<List<GenericListVm>>(maintainers);
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                if (AppStateComponent is not null && AppStateComponent.MaintainerId is not null)
                {
                    await Task.Delay(0);
                    SelectedMaintainerId = AppStateComponent.MaintainerId != null ? AppStateComponent.MaintainerId : 0;
                }
            }
            catch
            {
            }
        }
    }
}
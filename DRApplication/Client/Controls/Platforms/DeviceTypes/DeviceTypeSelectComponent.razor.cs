using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls
{
    public partial class DeviceTypeSelectComponent
    {
        [Parameter]
        public EventCallback<int?> DeviceTypeIdChange { get; set; }

        [Parameter]
        public int? SelectedDeviceTypeId { get; set; }

        [CascadingParameter]
        public AppStateComponent? AppStateComponent { get; set; }

        private List<GenericListVm> _deviceTypeVms = new();
        private async Task ChangeDeviceType(int? value)
        {
            if (AppStateComponent is not null)
            {
                SelectedDeviceTypeId = Convert.ToInt32(value);
                AppStateComponent.AppStateReset();
                await DeviceTypeIdChange.InvokeAsync(SelectedDeviceTypeId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var deviceTypes = await manager.GetAllAsync();
            _deviceTypeVms = Mapping.Mapper.Map<List<GenericListVm>>(deviceTypes);
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                if (AppStateComponent is not null && AppStateComponent.DeviceTypeId is not null)
                {
                    await Task.Delay(0);
                    SelectedDeviceTypeId = AppStateComponent.DeviceTypeId != null ? AppStateComponent.DeviceTypeId : 0;
                }
            }
            catch
            {
            }
        }
    }
}
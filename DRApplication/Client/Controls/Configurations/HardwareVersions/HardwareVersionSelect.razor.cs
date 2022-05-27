using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.Controls.Generic;
using DRApplication.Client.ViewModels;
namespace DRApplication.Client.Controls.Configurations;

public partial class HardwareVersionSelect
{
    [Parameter]
    public EventCallback<int?> HardwareVersionIdChange { get; set; }

    [Parameter]
    public int? SelectedHardwareVersionId { get; set; }

    [CascadingParameter]
    public AppStateComponent? AppStateComponent { get; set; }

    private List<GenericListVm> _hardwareVersionVms = new();
    private async Task ChangeHardwareVersion(int? value)
    {
        if (AppStateComponent is not null)
        {
            SelectedHardwareVersionId = Convert.ToInt32(value);
            AppStateComponent.AppStateReset();
            await HardwareVersionIdChange.InvokeAsync(SelectedHardwareVersionId);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var hardwareVersions = await manager.GetAllAsync();
        _hardwareVersionVms = Mapping.Mapper.Map<List<GenericListVm>>(hardwareVersions);
    }

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            if (AppStateComponent is not null && AppStateComponent.HardwareVersionId is not null)
            {
                await Task.Delay(0);
                SelectedHardwareVersionId = AppStateComponent.HardwareVersionId != null ? AppStateComponent.HardwareVersionId : 0;
            }
        }
        catch
        {
        }
    }
}

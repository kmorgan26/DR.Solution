using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.Controls.Generic;
using DRApplication.Client.ViewModels.Shared;
namespace DRApplication.Client.Controls.Configurations;

public partial class LoadSelect
{
    [Parameter]
    public EventCallback<int?> LoadIdChange { get; set; }

    [Parameter]
    public int? SelectedLoadId { get; set; }

    [CascadingParameter]
    public AppStateComponent? AppStateComponent { get; set; }

    private List<GenericListVm> _loadVms = new();
    private async Task ChangeLoad(int? value)
    {
        if (AppStateComponent is not null)
        {
            SelectedLoadId = Convert.ToInt32(value);
            AppStateComponent.AppStateReset();
            await LoadIdChange.InvokeAsync(SelectedLoadId);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var loads = await manager.GetAllAsync();
        _loadVms = Mapping.Mapper.Map<List<GenericListVm>>(loads);
    }

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            if (AppStateComponent is not null && AppStateComponent.LoadId is not null)
            {
                await Task.Delay(0);
                SelectedLoadId = AppStateComponent.LoadId != null ? AppStateComponent.LoadId : 0;
            }
        }
        catch
        {
        }
    }
}

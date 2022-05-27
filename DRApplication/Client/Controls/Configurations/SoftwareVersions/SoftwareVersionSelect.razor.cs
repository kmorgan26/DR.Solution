using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.Controls.Generic;
using DRApplication.Client.ViewModels;
namespace DRApplication.Client.Controls;

public partial class SoftwareVersionSelect
{
    [Parameter]
    public EventCallback<int?> SoftwareVersionIdChange { get; set; }

    [Parameter]
    public int? SelectedSoftwareVersionId { get; set; }

    [CascadingParameter]
    public AppStateComponent? AppStateComponent { get; set; }

    private List<GenericListVm> _softwareVersionVms = new();
    private async Task ChangeSoftwareVersion(int? value)
    {
        if (AppStateComponent is not null)
        {
            SelectedSoftwareVersionId = Convert.ToInt32(value);
            AppStateComponent.AppStateReset();
            await SoftwareVersionIdChange.InvokeAsync(SelectedSoftwareVersionId);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var softwareVersions = await manager.GetAllAsync();
        _softwareVersionVms = Mapping.Mapper.Map<List<GenericListVm>>(softwareVersions);
    }

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            if (AppStateComponent is not null && AppStateComponent.SoftwareVersionId is not null)
            {
                await Task.Delay(0);
                SelectedSoftwareVersionId = AppStateComponent.SoftwareVersionId != null ? AppStateComponent.SoftwareVersionId : 0;
            }
        }
        catch
        {
        }
    }
}

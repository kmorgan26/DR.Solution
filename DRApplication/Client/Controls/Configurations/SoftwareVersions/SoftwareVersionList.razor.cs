using Microsoft.AspNetCore.Components;
using MudBlazor;
using DRApplication.Client.ViewModels;
using DRApplication.Client.Services;

namespace DRApplication.Client.Controls;

public partial class SoftwareVersionList
{
    bool _isBusy;
    private int selectedRowNumber = -1;
    private MudTable<SoftwareVersionVm> mudTable;
    private List<string> clickedEvents = new();
    private string SelectedRowClassFunc(SoftwareVersionVm element, int rowNumber)
    {
        if (selectedRowNumber == rowNumber)
        {
            AppState.UpdateSoftwareVersionVm(this, new SoftwareVersionVm());
            selectedRowNumber = -1;
            clickedEvents.Add("Selected Row: None");
            return string.Empty;
        }
        else if (mudTable.SelectedItem != null && mudTable.SelectedItem.Equals(element))
        {
            AppState.UpdateSoftwareVersionVm(this, element);
            selectedRowNumber = rowNumber;
            clickedEvents.Add($"Selected Row: {rowNumber}");
            return "selected";
        }
        else
        {
            return string.Empty;
        }
    }

    private void RowClickEvent(TableRowClickEventArgs<SoftwareVersionVm> tableRowClickEventArgs)
    {
        clickedEvents.Add("Row has been clicked");
    }

    async Task SetSoftwareVersions()
    {
        var items = await LoadBuilderService.GetSoftwareVersionVmsBySoftwareSystemId(AppState.SoftwareSystemVm.Id);
        AppState.UpdateSoftwareVersionVms(this, items);
    }

    private async Task AppState_StateChanged(ComponentBase Source, string Property)
    {
        if (Source != this)
        {
            if (Property == "SoftwareSystemVm")
            {
                await SetSoftwareVersions();
                AppState.UpdateSoftwareVersionVm(this, new SoftwareVersionVm());
            }

            await InvokeAsync(StateHasChanged);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        _isBusy = true;
        AppState.StateChanged += async (Source, Property) => await AppState_StateChanged(Source, Property);
        await SetSoftwareVersions();
        _isBusy = false;
    }

    void IDisposable.Dispose()
    {
        AppState.StateChanged -= async (Source, Property) => await AppState_StateChanged(Source, Property);
    }
}
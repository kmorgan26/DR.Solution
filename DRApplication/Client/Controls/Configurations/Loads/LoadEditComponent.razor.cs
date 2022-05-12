using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;
using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Controls.Configurations;

public partial class LoadEditComponent
{
    [Parameter]
    public int LoadId { get; set; }

    public LoadEditVm LoadEditVm { get; set; } = new();
    void UpdateDeviceType(int? id)
    {
        LoadEditVm.DeviceTypeId = Convert.ToInt32(id);
    }

    protected async Task UpdateHarwareConfig()
    {
        var load = Mapping.Mapper.Map<Load>(LoadEditVm);
        await manager.UpdateAsync(load);
        navigation.NavigateTo("/load");
    }

    protected override async Task OnInitializedAsync()
    {
        var load = await manager.GetByIdAsync(LoadId);
        LoadEditVm = Mapping.Mapper.Map<LoadEditVm>(load);
    }
}

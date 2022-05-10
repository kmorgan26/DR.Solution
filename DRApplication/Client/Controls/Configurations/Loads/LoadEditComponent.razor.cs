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
        var hardwareConfig = Mapping.Mapper.Map<Load>(LoadEditVm);
        await manager.UpdateAsync(hardwareConfig);
        navigation.NavigateTo("/load");
    }

    protected override async Task OnInitializedAsync()
    {
        var hardwareConfig = await manager.GetByIdAsync(LoadId);
        LoadEditVm = Mapping.Mapper.Map<LoadEditVm>(hardwareConfig);
    }
}

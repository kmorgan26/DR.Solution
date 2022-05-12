using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;
using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Controls.Configurations;

public partial class VersionsLoadEditComponent
{
    [Parameter]
    public int VersionsLoadId { get; set; }

    public VersionsLoadEditVm VersionsLoadEditVm { get; set; } = new();
    
    void UpdateLoadId(int? id)
    {
        VersionsLoadEditVm.LoadId = Convert.ToInt32(id);
    }
    void UpdateSoftwareVersionId(int? id)
    {
        VersionsLoadEditVm.SoftwareVersionId = Convert.ToInt32(id);
    }

    protected async Task UpdateHarwareConfig()
    {
        var versionsLoad = Mapping.Mapper.Map<VersionsLoad>(VersionsLoadEditVm);
        await manager.UpdateAsync(versionsLoad);
        navigation.NavigateTo("/versionsload");
    }

    protected override async Task OnInitializedAsync()
    {
        var versionsLoad = await manager.GetByIdAsync(VersionsLoadId);
        VersionsLoadEditVm = Mapping.Mapper.Map<VersionsLoadEditVm>(versionsLoad);
    }
}

using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Controls.Configurations;

public partial class VersionsLoadInsertComponent
{
    private VersionsLoadInsertVm _versionsLoadInsertVm { get; set; } = new();
    void UpdateVersion(int? id)
    {
        _versionsLoadInsertVm.SoftwareVersionId = Convert.ToInt32(id);
    }

    void UpdateLoad(int? id)
    {
        _versionsLoadInsertVm.LoadId = Convert.ToInt32(id);
    }

    private async Task InsertVersionLoad()
    {
        var versionsLoad = Mapping.Mapper.Map<VersionsLoad>(_versionsLoadInsertVm);
        await manager.InsertAsync(versionsLoad);
        navigation.NavigateTo("/versionsload");
    }
}

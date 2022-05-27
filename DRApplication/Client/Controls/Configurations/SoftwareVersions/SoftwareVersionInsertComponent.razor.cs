using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Controls;

public partial class SoftwareVersionInsertComponent
{
    private SoftwareVersionInsertVm _softwareVersionInsertVm { get; set; } = new();
    void UpdateSoftwareSystem(int? id)
    {
        _softwareVersionInsertVm.SoftwareSystemId = Convert.ToInt32(id);
    }

    private async Task InsertSoftwareVersion()
    {
        var softwareVersion = Mapping.Mapper.Map<SoftwareVersion>(_softwareVersionInsertVm);
        await manager.InsertAsync(softwareVersion);
        navigation.NavigateTo("/softwareversion");
    }
}

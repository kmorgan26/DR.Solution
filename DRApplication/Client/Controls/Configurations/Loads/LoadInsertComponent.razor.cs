using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;
using DRApplication.Shared.Models.ConfigurationModels;
namespace DRApplication.Client.Controls.Configurations;

public partial class LoadInsertComponent
{
    private LoadInsertVm _loadInsertVm { get; set; } = new();
    void UpdateDeviceType(int? id)
    {
        _loadInsertVm.DeviceTypeId = Convert.ToInt32(id);
    }

    private async Task InsertLoad()
    {
        var load = Mapping.Mapper.Map<Load>(_loadInsertVm);
        await manager.InsertAsync(load);
        navigation.NavigateTo("/load");
    }
}
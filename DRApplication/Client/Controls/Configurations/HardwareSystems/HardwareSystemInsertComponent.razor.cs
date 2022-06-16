using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Controls
{
    public partial class HardwareSystemInsertComponent
    {
        private HardwareSystemInsertVm _harwareSystemInsertVm { get; set; } = new();
        private async Task InsertHardwareSystem()
        {
            var hardwareSystem = Mapping.Mapper.Map<HardwareSystem>(_harwareSystemInsertVm);
            await manager.InsertAsync(hardwareSystem);
            navigation.NavigateTo("/hardwaresystem");
        }
    }
}
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareVersionInsertComponent
    {
        private HardwareVersionInsertVm _hardwareVersionInsertVm { get; set; } = new();
        void UpdateHardwareSystem(int? id)
        {
            _hardwareVersionInsertVm.HardwareSystemId = Convert.ToInt32(id);
        }

        private async Task InsertHardwareVersion()
        {
            var hardwareVersion = Mapping.Mapper.Map<HardwareVersion>(_hardwareVersionInsertVm);
            await manager.InsertAsync(hardwareVersion);
            navigation.NavigateTo("/hardwareversion");
        }
    }
}
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls
{
    public partial class HardwareConfigInsertComponent
    {
        private HardwareConfigInsertVm _hardwareConfigInsertVm { get; set; } = new();
        void UpdateDeviceType(int? id)
        {
            _hardwareConfigInsertVm.DeviceTypeId = Convert.ToInt32(id);
        }

        private async Task InsertHardwareConfig()
        {
            var hardwareSystem = Mapping.Mapper.Map<HardwareConfig>(_hardwareConfigInsertVm);
            await manager.InsertAsync(hardwareSystem);
            navigation.NavigateTo("/hardwareconfig");
        }
    }
}
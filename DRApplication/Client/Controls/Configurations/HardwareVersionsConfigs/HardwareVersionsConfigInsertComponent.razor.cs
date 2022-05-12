using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class HardwareVersionsConfigInsertComponent
    {
        private HardwareVersionsConfigInsertVm _hardwareVersionsConfigInsertVm { get; set; } = new();
        void UpdateVersion(int? id)
        {
            _hardwareVersionsConfigInsertVm.HardwareVersionId = Convert.ToInt32(id);
        }

        void UpdateConfig(int? id)
        {
            _hardwareVersionsConfigInsertVm.HardwareConfigId = Convert.ToInt32(id);
        }

        private async Task InsertHardwareVersionConfig()
        {
            var hardwareVersionConfig = Mapping.Mapper.Map<HardwareVersionsConfig>(_hardwareVersionsConfigInsertVm);
            await manager.InsertAsync(hardwareVersionConfig);
            navigation.NavigateTo("/hardwareversionsconfig");
        }
    }
}
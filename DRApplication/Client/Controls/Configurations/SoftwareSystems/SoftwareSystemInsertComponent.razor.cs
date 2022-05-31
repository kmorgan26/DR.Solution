using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Controls
{
    public partial class SoftwareSystemInsertComponent
    {
        private SoftwareSystemInsertVm _softwareSystemInsertVm { get; set; } = new();
        void UpdateConfig(int? id)
        {
            _softwareSystemInsertVm.HardwareConfigId = Convert.ToInt32(id);
        }

        private async Task InsertSoftwareSystem()
        {
            var softwareSystem = Mapping.Mapper.Map<SoftwareSystem>(_softwareSystemInsertVm);
            await manager.InsertAsync(softwareSystem);
            navigation.NavigateTo("/softwaresystem");
        }
    }
}
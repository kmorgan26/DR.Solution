using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.ConfigurationViewModels.HardwareConfigs
{
    public class HardwareConfigVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DeviceTypeId { get; set; }
        
    }
}

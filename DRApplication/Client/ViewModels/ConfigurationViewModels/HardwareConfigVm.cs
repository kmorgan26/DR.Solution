using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.ConfigurationViewModels
{
    public class HardwareConfigVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Device Type")]
        public string DeviceTypeName { get; set; } = string.Empty;
        
    }
}

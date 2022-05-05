using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.DeviceViewModels
{
    public class DeviceVm
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Device Type")]
        public string DeviceTypeName { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }

    }
}

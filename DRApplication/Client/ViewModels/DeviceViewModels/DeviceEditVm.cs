using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.DeviceViewModels
{
    public class DeviceEditVm
    {
        public int Id { get; set; }
        
        [Required]
        [Range(1, 50, ErrorMessage = "Device Name cannot be more than 20 characters long")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 100, ErrorMessage = "Please Select a Device Type for this Device")]
        public int DeviceTypeId { get; set; }
        
        public bool IsActive { get; set; }
    }
}

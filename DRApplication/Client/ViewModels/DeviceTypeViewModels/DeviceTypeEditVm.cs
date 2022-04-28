using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.DeviceTypeViewModels
{
    public class DeviceTypeEditVm
    {
        public int Id { get; set; }
        
        [Required]
        [Range(1, 50, ErrorMessage = "Device Type Name cannot be more than 255 characters long")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 100, ErrorMessage = "Please Select a Maintainer for this Device Type")]
        public int MaintainerId { get; set; }
        
        public bool IsActive { get; set; }
    }
}

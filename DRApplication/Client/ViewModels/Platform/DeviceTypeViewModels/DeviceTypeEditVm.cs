using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class DeviceTypeEditVm
{
    public int Id { get; set; }
    
    [Required(ErrorMessage ="You must enter a name for the Device Type. Otherwise, what would we call it?")]
    [MaxLength(255, ErrorMessage = "Device Type Name cannot be more than 255 characters long")]
    public string Name { get; set; } = null!;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Maintainer for this Device Type")]
    public int MaintainerId { get; set; }
    
    public bool IsActive { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels;

public class DeviceTypeInsertVm
{
    [Required]
    [Range(1, 50, ErrorMessage = "Platform Name cannot be more than 50 characters long")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Maintainer for this Device")]
    public int MaintainerId { get; set; }
    
    public bool IsActive { get; set; } = true;
}

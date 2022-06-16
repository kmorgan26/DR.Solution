using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class DeviceInsertVm
{
    [Required]
    [Range(1, 50, ErrorMessage = "Device Name cannot be more than 20 characters long")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Platform for this Device")]
    public int DeviceTypeId { get; set; }

    public bool IsActive { get; set; } = true;
}

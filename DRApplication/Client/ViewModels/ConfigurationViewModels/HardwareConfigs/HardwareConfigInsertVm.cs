using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;
public class HardwareConfigInsertVm
{
    [Required]
    [Range(1, 50, ErrorMessage = "Hardware Config Name cannot be more than 50 characters long")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Device Type")]
    public int DeviceTypeId { get; set; }

}
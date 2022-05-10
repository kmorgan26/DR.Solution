using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Configuration;

public class HardwareConfigEditVm
{
    public int Id { get; set; }
    
    [Required]
    [Range(1,50,ErrorMessage = "Hardware Config cannot be more than 50 characters long")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Device Type")]
    public int DeviceTypeId { get; set; }
}

using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;
public class HardwareSystemInsertVm
{
    [Required]
    [Range(1, 50, ErrorMessage = "Hardware System Name cannot be more than 50 characters long")]
    public string Name { get; set; } = string.Empty;

}
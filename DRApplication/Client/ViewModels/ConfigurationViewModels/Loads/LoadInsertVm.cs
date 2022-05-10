using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Configuration;

public class LoadInsertVm
{
    [Required]
    [Range(1, 50, ErrorMessage = "Load Name cannot be more than 50 characters long")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Hardware Configuration")]
    public int DeviceTypeId { get; set; }
}
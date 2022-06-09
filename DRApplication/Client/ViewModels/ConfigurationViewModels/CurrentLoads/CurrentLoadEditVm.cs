using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class CurrentLoadEditVm
{
    public int Id { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Load")]
    public int LoadId { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Device")]
    public int DeviceId { get; set; }
}
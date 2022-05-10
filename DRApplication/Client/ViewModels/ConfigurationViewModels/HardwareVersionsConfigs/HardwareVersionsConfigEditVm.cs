using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Configuration;
public class HardwareVersionsConfigEditVm
{
    public int Id { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Hardware Version")]
    public int HardwareVersionId { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Hardware Configuration")]
    public int HardwareConfigId { get; set; }
}

using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Configuration;

public class HardwareVersionsConfigInsertVm
{
    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Hardware Version")]
    public int HardwareVersionId { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Hardware Config")]
    public int HardwareConfigId { get; set; }

}

using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Configuration;

public class VersionsLoadInsertVm
{
    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Test Load")]
    public int LoadId { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Software Version")]
    public int SoftwareVersionId { get; set; }
}

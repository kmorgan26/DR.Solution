using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class VersionsLoadEditVm
{
    public int Id { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Test Load")]
    public int LoadId { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Software Version")]
    public int SoftwareVersionId { get; set; }
}

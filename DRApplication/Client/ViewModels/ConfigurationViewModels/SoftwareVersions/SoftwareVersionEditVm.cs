using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Configuration;
public class SoftwareVersionEditVm
{
    public int Id { get; set; }

    [Required]
    [Range(1, 50, ErrorMessage = "Software Version Name cannot be more than 50 characters long")]
    public string Name { get; set; } = null!;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Software System")]
    public int SoftwareSystemId { get; set; }

    [Required]
    public DateTime VersionDate { get; set; }

}
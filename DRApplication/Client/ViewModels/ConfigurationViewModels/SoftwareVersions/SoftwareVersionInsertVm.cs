using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Configuration;

public class SoftwareVersionInsertVm
{
    [Required]
    [Range(1, 50, ErrorMessage = "Software Version Name cannot be more than 50 characters long")]
    public string Name { get; set; } = null!;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Software System")]
    public int SoftwareSystemId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime VersionDate { get; set; } = DateTime.Today;
}

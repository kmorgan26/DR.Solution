using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Configuration;
public class HardwareVersionEditVm
{
    public int Id { get; set; }

    [Required]
    [Range(1, 50, ErrorMessage = "Hardware Version Name cannot be more than 50 characters long")]
    public string Name { get; set; } = null!;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Hardware System")]
    public int HardwareSystemId { get; set; }

    [Required]
    public DateTime VersionDate { get; set; }

}

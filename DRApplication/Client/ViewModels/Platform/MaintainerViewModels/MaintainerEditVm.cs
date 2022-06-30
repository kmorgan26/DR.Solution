using DRApplication.Client.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class MaintainerEditVm
{
    public int Id { get; set; }

    [Required]
    [Range(1, 255, ErrorMessage = "Maintainer Name cannot be more than 255 characters long")]
    public string Name { get; set; } = null!;

}

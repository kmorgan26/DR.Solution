using DRApplication.Client.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class DeviceTypeVm : IDeviceTypeVm
{
    public int Id { get; set; }

    [Required(ErrorMessage = "You must enter a name for the Platform. Otherwise, what would we call it?")]
    [MaxLength(255, ErrorMessage = "Platform Name cannot be more than 255 characters long")]
    public string Platform { get; set; } = string.Empty;

    public string Maintainer { get; set; }=string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Please Select a Maintainer for this Device Type")]
    public int MaintainerId { get; set; }

    public bool IsActive { get; set; }
}

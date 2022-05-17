using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Platform;

public class DeviceVm
{
    public int Id { get; set; }
    
    public string Device { get; set; } = string.Empty;

    [Display(Name ="Device Type")]
    public string Platform { get; set; } = string.Empty;

    public bool IsActive { get; set; }

}

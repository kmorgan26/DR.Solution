using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Platform;

public class DeviceVm
{
    public int Id { get; set; }
    
    public string Device { get; set; } = string.Empty;

    public string Platform { get; set; } = string.Empty;

    public int DeviceTypeId { get; set; }

    public bool IsActive { get; set; }

}

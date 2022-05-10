using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Platform;

public class DeviceTypeVm
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int MaintainerId { get; set; }
    
    public bool IsActive { get; set; }
}

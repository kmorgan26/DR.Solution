using DRApplication.Client.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels.Platform;

public class DeviceTypeVm : IDeviceTypeVm
{
    public int Id { get; set; }

    public string Platform { get; set; } = string.Empty;

    public string Maintainer { get; set; }=string.Empty;
    
    public bool IsActive { get; set; }
}

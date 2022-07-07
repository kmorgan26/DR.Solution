namespace DRApplication.Client.ViewModels;

public class DeviceTypeVm
{
    public int Id { get; set; } = 0;
    public string Platform { get; set; } = string.Empty;
    public string Maintainer { get; set; }= string.Empty;
    public int MaintainerId { get; set; }
    public bool IsActive { get; set; }
}
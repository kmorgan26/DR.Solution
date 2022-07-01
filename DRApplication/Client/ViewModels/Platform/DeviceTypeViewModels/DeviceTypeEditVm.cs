namespace DRApplication.Client.ViewModels;

public class DeviceTypeEditVm
{
    public int Id { get; set; } = 0;
    public string Platform { get; set; } = string.Empty;
    public int MaintainerId { get; set; } = 0;
    public bool IsActive { get; set; }
}
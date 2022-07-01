namespace DRApplication.Client.ViewModels;

public class DeviceTypeInsertVm
{
    public string Platform { get; set; } = string.Empty;
    public int MaintainerId { get; set; }
    public bool IsActive { get; set; } = true;
}
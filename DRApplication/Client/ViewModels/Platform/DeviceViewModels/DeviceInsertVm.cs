namespace DRApplication.Client.ViewModels;

public class DeviceInsertVm
{
    public string Device { get; set; } = string.Empty;
    public int DeviceTypeId { get; set; }
    public bool IsActive { get; set; } = true;
}
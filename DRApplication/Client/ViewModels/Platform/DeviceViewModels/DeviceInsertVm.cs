namespace DRApplication.Client.ViewModels;

public class DeviceInsertVm
{
    public string Name { get; set; } = string.Empty;
    public int DeviceTypeId { get; set; }
    public bool IsActive { get; set; } = true;
}
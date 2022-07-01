namespace DRApplication.Client.ViewModels;
public class DeviceEditVm
{
    public int Id { get; set; } = 0;
    public string Device { get; set; } = string.Empty;
    public int DeviceTypeId { get; set; } = 0;
    public bool IsActive { get; set; }
}
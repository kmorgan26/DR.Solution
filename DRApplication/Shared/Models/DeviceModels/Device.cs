namespace DRApplication.Shared.Models;

public class Device
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DeviceTypeId { get; set; }
    public bool IsActive { get; set; }
}
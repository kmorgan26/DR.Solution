namespace DRApplication.Shared.Models;
public class DeviceType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MaintainerId { get; set; }
    public bool IsActive { get; set; }

}
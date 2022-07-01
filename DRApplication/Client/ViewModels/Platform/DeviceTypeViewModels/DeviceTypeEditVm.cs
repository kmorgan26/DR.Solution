namespace DRApplication.Client.ViewModels;

public class DeviceTypeEditVm
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int MaintainerId { get; set; }
    public bool IsActive { get; set; }
}
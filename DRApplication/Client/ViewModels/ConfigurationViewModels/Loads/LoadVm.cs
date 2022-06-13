namespace DRApplication.Client.ViewModels;

public class LoadVm
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int DeviceTypeId { get; set; } = 0;

    public bool IsAccepted { get; set; } = false;
}

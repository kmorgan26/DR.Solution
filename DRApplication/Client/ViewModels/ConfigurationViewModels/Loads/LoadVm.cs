namespace DRApplication.Client.ViewModels;

public class LoadVm
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int HardwareConfigId { get; set; } = 0;

    public bool IsAccepted { get; set; } = false;
}

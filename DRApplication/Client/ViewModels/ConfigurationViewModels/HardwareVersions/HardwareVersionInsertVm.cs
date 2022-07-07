namespace DRApplication.Client.ViewModels;

public class HardwareVersionInsertVm
{
    public string Name { get; set; } = string.Empty;
    public int HardwareSystemId { get; set; } = 0;
    public DateTime? VersionDate { get; set; } = DateTime.Today;
}
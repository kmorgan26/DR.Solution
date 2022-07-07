namespace DRApplication.Client.ViewModels;
public class HardwareVersionEditVm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int HardwareSystemId { get; set; } = 0;
    public DateTime? VersionDate { get; set; } = DateTime.Today;

}
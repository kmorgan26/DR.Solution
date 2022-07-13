namespace DRApplication.Client.ViewModels;

public class SoftwareVersionVm
{
    public int Id { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public int SoftwareSystemId { get; set; } = 0;

    public DateTime? VersionDate { get; set; }

}
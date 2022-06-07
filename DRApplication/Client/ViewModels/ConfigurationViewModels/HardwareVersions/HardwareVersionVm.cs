using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class HardwareVersionVm
{
    public int Id { get; set; } = 0;
    
    public string Name { get; set; } = string.Empty;

    public int HardwareSystemId { get; set; } = 0;
    
    public DateTime? VersionDate { get; set; }

}

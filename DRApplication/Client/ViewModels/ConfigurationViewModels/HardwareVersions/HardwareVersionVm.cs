using System.ComponentModel.DataAnnotations;
namespace DRApplication.Client.ViewModels;

public class HardwareVersionVm
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int HardwareSystemId { get; set; }
    
    public DateTime VersionDate { get; set; }

}

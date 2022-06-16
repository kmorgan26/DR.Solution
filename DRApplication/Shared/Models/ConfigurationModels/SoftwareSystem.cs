using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models;

[Table("SoftwareSystems")]
public class SoftwareSystem
{
    [Key]
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int HardwareConfigId { get; set; }= 0;

}
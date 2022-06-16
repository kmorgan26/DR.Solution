using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models;

[Table("HardwareVersions")]
public class HardwareVersion
{
    [Key]
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int HardwareSystemId { get; set; } = 0;
    public DateTime VersionDate { get; set; }
}

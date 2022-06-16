using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models;

[Table("HardwareSystems")]
public class HardwareSystem
{
    [Key]
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
}
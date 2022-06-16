using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models;

[Table("HardwareConfigs")]
public class HardwareConfig
{
    [Key]
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int DeviceTypeId { get; set; } = 0;
}
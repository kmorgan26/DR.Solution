using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models;

[Table("HardwareVersionsConfigs")]
public class HardwareVersionsConfig
{
    [Key]
    public int Id { get; set; } = 0;
    public int HardwareVersionId { get; set; } = 0;
    public int HardwareConfigId { get; set; } = 0;
}
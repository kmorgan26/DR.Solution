using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models;

[Table("CurrentLoads")]
public class CurrentLoad
{
    [Key]
    public int Id { get; set; } = 0;
    public int LoadId { get; set; } = 0;
    public int DeviceId { get; set; } = 0;
}
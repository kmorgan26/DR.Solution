using Dapper.Contrib.Extensions;

namespace DRApplication.Shared.Models;

[Table("DeviceDiscovered")]
public class DeviceDiscovered
{
    [Key]
    public int Id { get; set; }
    public int IssueId { get; set; }
    public int DeviceId { get; set; }

}
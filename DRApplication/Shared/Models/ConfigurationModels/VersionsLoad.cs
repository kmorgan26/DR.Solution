using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models;

[Table("VersionsLoads")]
public class VersionsLoad
{
    [Key]
    public int Id { get; set; }
    public int LoadId { get; set; }
    public int SoftwareVersionId { get; set; }
}
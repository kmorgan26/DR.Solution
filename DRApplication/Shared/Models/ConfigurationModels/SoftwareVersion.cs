using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models.ConfigurationModels;

[Table("SoftwareVersions")]
public partial class SoftwareVersion
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int SoftwareSystemId { get; set; }
    public DateTime VersionDate { get; set; }
}
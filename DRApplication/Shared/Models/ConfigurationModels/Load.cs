using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models.ConfigurationModels;

[Table("Loads")]
public partial class Load
{
    [Key]
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int HardwareConfigId { get; set; } = 0;

    public bool IsAccepted { get; set; }
}

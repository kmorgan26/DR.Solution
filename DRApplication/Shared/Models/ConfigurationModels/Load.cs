using Dapper.Contrib.Extensions;
namespace DRApplication.Shared.Models.ConfigurationModels;

[Table("Loads")]
public partial class Load
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DeviceTypeId { get; set; }
}

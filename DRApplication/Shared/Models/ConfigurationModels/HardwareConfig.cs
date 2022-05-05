using DRApplication.Shared.Models.DeviceModels;
using Dapper.Contrib.Extensions;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    [Table("HardwareConfigs")]
    public partial class HardwareConfig
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceTypeId { get; set; }

    }
}
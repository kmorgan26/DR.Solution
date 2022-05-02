using DRApplication.Shared.Models.DeviceModels;
using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    [Table("HardwareConfig")]
    public partial class HardwareConfig
    {
        public HardwareConfig()
        {
            HardwareVersionsConfigs = new HashSet<HardwareVersionsConfig>();
            SoftwareSystems = new HashSet<SoftwareSystem>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; } = null!;
        public virtual ICollection<HardwareVersionsConfig> HardwareVersionsConfigs { get; set; }
        public virtual ICollection<SoftwareSystem> SoftwareSystems { get; set; }
    }
}



using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    public partial class HardwareVersion
    {
        public HardwareVersion()
        {
            HardwareVersionsConfigs = new HashSet<HardwareVersionsConfig>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int HardwareSystemId { get; set; }
        public DateTime VersionDate { get; set; }

        public virtual HardwareSystem HardwareSystem { get; set; } = null!;
        public virtual ICollection<HardwareVersionsConfig> HardwareVersionsConfigs { get; set; }
    }
}

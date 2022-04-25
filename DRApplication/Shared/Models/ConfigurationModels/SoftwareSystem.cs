using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    public partial class SoftwareSystem
    {
        public SoftwareSystem()
        {
            SoftwareVersions = new HashSet<SoftwareVersion>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int HardwareConfigId { get; set; }

        public virtual HardwareConfig HardwareConfig { get; set; } = null!;
        public virtual ICollection<SoftwareVersion> SoftwareVersions { get; set; }
    }
}

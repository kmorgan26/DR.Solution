using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    public partial class HardwareVersionsConfig
    {
        public int Id { get; set; }
        public int HardwareVersionId { get; set; }
        public int HardwareConfigId { get; set; }

        public virtual HardwareConfig HardwareConfig { get; set; } = null!;
        public virtual HardwareVersion HardwareVersion { get; set; } = null!;
    }
}

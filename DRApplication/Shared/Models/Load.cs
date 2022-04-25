using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class Load
    {
        public Load()
        {
            LoadsDevices = new HashSet<LoadsDevice>();
            LoadsTestEvents = new HashSet<LoadsTestEvent>();
            VersionsLoads = new HashSet<VersionsLoad>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceTypeId { get; set; }

        public virtual ICollection<LoadsDevice> LoadsDevices { get; set; }
        public virtual ICollection<LoadsTestEvent> LoadsTestEvents { get; set; }
        public virtual ICollection<VersionsLoad> VersionsLoads { get; set; }
    }
}

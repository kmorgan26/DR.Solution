using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class HardwareSystem
    {
        public HardwareSystem()
        {
            HardwareVersions = new HashSet<HardwareVersion>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<HardwareVersion> HardwareVersions { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.DeviceModels
{
    public partial class Maintainer
    {
        public Maintainer()
        {
            DeviceTypes = new HashSet<DeviceType>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DeviceType> DeviceTypes { get; set; }
    }
}

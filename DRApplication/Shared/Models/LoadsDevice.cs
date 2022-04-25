using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class LoadsDevice
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int LoadId { get; set; }

        public virtual Device Device { get; set; } = null!;
        public virtual Load Load { get; set; } = null!;
    }
}

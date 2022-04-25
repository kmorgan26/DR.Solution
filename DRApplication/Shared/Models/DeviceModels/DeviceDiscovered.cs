using DRApplication.Shared.Models.IssueModels;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.DeviceModels
{
    public partial class DeviceDiscovered
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; } = null!;
        public virtual Issue Issue { get; set; } = null!;
    }
}

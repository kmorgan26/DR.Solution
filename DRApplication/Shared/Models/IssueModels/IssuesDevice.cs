using DRApplication.Shared.Models.DeviceModels;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.IssueModels
{
    public partial class IssuesDevice
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; } = null!;
        public virtual Issue Issue { get; set; } = null!;
    }
}

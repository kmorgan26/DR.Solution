using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class IssueSsrdTask
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int SsrdTaskId { get; set; }

        public virtual Issue Issue { get; set; } = null!;
        public virtual SsrdTask SsrdTask { get; set; } = null!;
    }
}

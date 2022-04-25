using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class MaintIssue
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public string Pid { get; set; } = null!;
        public int CorrectiveActionId { get; set; }

        public virtual CorrectiveAction CorrectiveAction { get; set; } = null!;
        public virtual Issue Issue { get; set; } = null!;
    }
}

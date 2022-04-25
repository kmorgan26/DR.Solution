using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class ResearchInfo
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public DateTime ResearchDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public string ResearchLead { get; set; } = null!;

        public virtual Issue Issue { get; set; } = null!;
    }
}

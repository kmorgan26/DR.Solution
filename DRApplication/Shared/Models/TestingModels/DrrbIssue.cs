using DRApplication.Shared.Models.IssueModels;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.TestingModels
{
    public partial class DrrbIssue
    {
        public int Id { get; set; }
        public int DrrbId { get; set; }
        public int IssueId { get; set; }

        public virtual Drrb Drrb { get; set; } = null!;
        public virtual Issue Issue { get; set; } = null!;
    }
}

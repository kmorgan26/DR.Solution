using DRApplication.Shared.Models.IssueModels;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ClosureModels
{
    public partial class GrfrPlan
    {
        public int Id { get; set; }
        public int DrId { get; set; }
        public DateTime GrfrDate { get; set; }
        public string EnteredBy { get; set; } = null!;
        public DateTime EnteredDate { get; set; }

        public virtual Dr Dr { get; set; } = null!;
    }
}

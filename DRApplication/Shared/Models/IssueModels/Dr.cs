using System;
using System.Collections.Generic;
using DRApplication.Shared.Models.ClosureModels;
using DRApplication.Shared.Models.TestingModels;

namespace DRApplication.Shared.Models.IssueModels
{
    public partial class Dr
    {
        public Dr()
        {
            Baselines = new HashSet<Baseline>();
            DrDissents = new HashSet<DrDissent>();
            DrDuplicates = new HashSet<DrDuplicate>();
            GrfrHistories = new HashSet<GrfrHistory>();
            GrfrPlans = new HashSet<GrfrPlan>();
            TestEventDrs = new HashSet<TestEventDr>();
        }

        public int Id { get; set; }
        public int Priority { get; set; }
        public int IssueId { get; set; }

        public virtual Issue Issue { get; set; } = null!;
        public virtual ICollection<Baseline> Baselines { get; set; }
        public virtual ICollection<DrDissent> DrDissents { get; set; }
        public virtual ICollection<DrDuplicate> DrDuplicates { get; set; }
        public virtual ICollection<GrfrHistory> GrfrHistories { get; set; }
        public virtual ICollection<GrfrPlan> GrfrPlans { get; set; }
        public virtual ICollection<TestEventDr> TestEventDrs { get; set; }
    }
}

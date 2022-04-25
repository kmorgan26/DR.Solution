using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class SimStatus
    {
        public SimStatus()
        {
            Issues = new HashSet<Issue>();
            StatusChanges = new HashSet<StatusChange>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SimStatusTypeId { get; set; }
        public string IssueDisplayName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual SimStatusType SimStatusType { get; set; } = null!;
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<StatusChange> StatusChanges { get; set; }
    }
}

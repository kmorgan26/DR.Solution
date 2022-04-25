using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class CorrectiveAction
    {
        public CorrectiveAction()
        {
            MaintIssues = new HashSet<MaintIssue>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<MaintIssue> MaintIssues { get; set; }
    }
}

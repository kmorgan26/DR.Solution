using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.IssueModels
{
    public partial class DrType
    {
        public DrType()
        {
            Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Issue> Issues { get; set; }
    }
}

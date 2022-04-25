using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class RctdConfiguration
    {
        public RctdConfiguration()
        {
            IssueConfigurations = new HashSet<IssueConfiguration>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<IssueConfiguration> IssueConfigurations { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class Keyword
    {
        public Keyword()
        {
            IssuesKeywords = new HashSet<IssuesKeyword>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceTypeId { get; set; }
        public bool DeviceSpecific { get; set; }

        public virtual ICollection<IssuesKeyword> IssuesKeywords { get; set; }
    }
}

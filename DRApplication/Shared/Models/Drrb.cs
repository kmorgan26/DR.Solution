using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class Drrb
    {
        public Drrb()
        {
            DrrbIssues = new HashSet<DrrbIssue>();
        }

        public int Id { get; set; }
        public DateTime DrrbDate { get; set; }
        public int DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; } = null!;
        public virtual ICollection<DrrbIssue> DrrbIssues { get; set; }
    }
}

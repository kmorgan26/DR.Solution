using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.IssueModels
{
    public partial class DrDissent
    {
        public int Id { get; set; }
        public int GditPriority { get; set; }
        public int DosPriority { get; set; }
        public int ThirdPriority { get; set; }
        public int DrId { get; set; }

        public virtual Dr Dr { get; set; } = null!;
    }
}

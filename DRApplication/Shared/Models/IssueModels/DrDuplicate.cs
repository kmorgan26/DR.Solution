using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.IssueModels
{
    public partial class DrDuplicate
    {
        public int Id { get; set; }
        public int Drid { get; set; }
        public int DupDrid { get; set; }

        public virtual Dr Dr { get; set; } = null!;
    }
}

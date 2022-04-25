using DRApplication.Shared.Models.IssueModels;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ClosureModels
{
    public partial class Baseline
    {
        public int Id { get; set; }
        public DateTime BaseLineDate { get; set; }
        public int DrId { get; set; }
        public DateTime EnteredDate { get; set; }
        public string EnteredBy { get; set; } = null!;

        public virtual Dr Dr { get; set; } = null!;
    }
}

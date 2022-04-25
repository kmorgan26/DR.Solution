using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.IssueModels
{
    public partial class StatusChange
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int SimStatusId { get; set; }
        public string EnteredBy { get; set; } = null!;
        public DateTime EnteredDate { get; set; }

        public virtual Issue Issue { get; set; } = null!;
        public virtual SimStatus SimStatus { get; set; } = null!;
    }
}

using DRApplication.Shared.Models.IssueModels;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.TestingModels
{
    public partial class TestEventIssue
    {
        public int Id { get; set; }
        public int TestEventId { get; set; }
        public int IssueId { get; set; }

        public virtual Issue Issue { get; set; } = null!;
        public virtual TestEvent TestEvent { get; set; } = null!;
    }
}

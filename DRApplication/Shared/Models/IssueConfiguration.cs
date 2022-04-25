using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class IssueConfiguration
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int ConfigId { get; set; }

        public virtual RctdConfiguration Config { get; set; } = null!;
        public virtual Issue Issue { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class IssuesKeyword
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int KeywordId { get; set; }

        public virtual Issue Issue { get; set; } = null!;
        public virtual Keyword Keyword { get; set; } = null!;
    }
}

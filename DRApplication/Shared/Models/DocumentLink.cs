using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class DocumentLink
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int IssueId { get; set; }
        public string Url { get; set; } = null!;

        public virtual Issue Issue { get; set; } = null!;
    }
}

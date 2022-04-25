using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CommentDate { get; set; }
        public string EnteredBy { get; set; } = null!;

        public virtual Issue Issue { get; set; } = null!;
    }
}

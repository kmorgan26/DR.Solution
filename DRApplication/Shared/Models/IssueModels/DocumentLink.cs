using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public class DocumentLink
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int IssueId { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}

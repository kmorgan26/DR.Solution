using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Comments = new HashSet<Comment>();
            DeviceDiscovereds = new HashSet<DeviceDiscovered>();
            DocumentLinks = new HashSet<DocumentLink>();
            DrrbIssues = new HashSet<DrrbIssue>();
            Drs = new HashSet<Dr>();
            IssueConfigurations = new HashSet<IssueConfiguration>();
            IssueObserveds = new HashSet<IssueObserved>();
            IssueSsrdTasks = new HashSet<IssueSsrdTask>();
            IssuesDevices = new HashSet<IssuesDevice>();
            IssuesKeywords = new HashSet<IssuesKeyword>();
            MaintIssues = new HashSet<MaintIssue>();
            ResearchInfos = new HashSet<ResearchInfo>();
            StatusChanges = new HashSet<StatusChange>();
            TestEventIssues = new HashSet<TestEventIssue>();
        }

        public int Id { get; set; }
        public int DrTypeId { get; set; }
        public int SimStatusId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime IssueDate { get; set; }
        public string EnteredBy { get; set; } = null!;

        public virtual DrType DrType { get; set; } = null!;
        public virtual SimStatus SimStatus { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<DeviceDiscovered> DeviceDiscovereds { get; set; }
        public virtual ICollection<DocumentLink> DocumentLinks { get; set; }
        public virtual ICollection<DrrbIssue> DrrbIssues { get; set; }
        public virtual ICollection<Dr> Drs { get; set; }
        public virtual ICollection<IssueConfiguration> IssueConfigurations { get; set; }
        public virtual ICollection<IssueObserved> IssueObserveds { get; set; }
        public virtual ICollection<IssueSsrdTask> IssueSsrdTasks { get; set; }
        public virtual ICollection<IssuesDevice> IssuesDevices { get; set; }
        public virtual ICollection<IssuesKeyword> IssuesKeywords { get; set; }
        public virtual ICollection<MaintIssue> MaintIssues { get; set; }
        public virtual ICollection<ResearchInfo> ResearchInfos { get; set; }
        public virtual ICollection<StatusChange> StatusChanges { get; set; }
        public virtual ICollection<TestEventIssue> TestEventIssues { get; set; }
    }
}

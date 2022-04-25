using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class TestEvent
    {
        public TestEvent()
        {
            LoadsTestEvents = new HashSet<LoadsTestEvent>();
            TestEventDrs = new HashSet<TestEventDr>();
            TestEventIssues = new HashSet<TestEventIssue>();
        }

        public int Id { get; set; }
        public DateTime TestEventDate { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; } = null!;
        public virtual ICollection<LoadsTestEvent> LoadsTestEvents { get; set; }
        public virtual ICollection<TestEventDr> TestEventDrs { get; set; }
        public virtual ICollection<TestEventIssue> TestEventIssues { get; set; }
    }
}

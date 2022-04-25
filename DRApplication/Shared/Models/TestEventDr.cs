using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class TestEventDr
    {
        public int Id { get; set; }
        public int TestEventId { get; set; }
        public int DrId { get; set; }

        public virtual Dr Dr { get; set; } = null!;
        public virtual TestEvent TestEvent { get; set; } = null!;
    }
}

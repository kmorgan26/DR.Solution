using DRApplication.Shared.Models.TestingModels;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    public partial class LoadsTestEvent
    {
        public int Id { get; set; }
        public int TestEventId { get; set; }
        public int LoadId { get; set; }

        public virtual Load Load { get; set; } = null!;
        public virtual TestEvent TestEvent { get; set; } = null!;
    }
}

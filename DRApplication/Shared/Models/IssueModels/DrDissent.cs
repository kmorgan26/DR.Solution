using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public class DrDissent
    {
        public int Id { get; set; }
        public int GditPriority { get; set; }
        public int DosPriority { get; set; }
        public int ThirdPriority { get; set; }
        public int DrId { get; set; }
    }
}
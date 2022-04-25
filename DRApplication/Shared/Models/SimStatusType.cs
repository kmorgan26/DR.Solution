using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class SimStatusType
    {
        public SimStatusType()
        {
            SimStatuses = new HashSet<SimStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<SimStatus> SimStatuses { get; set; }
    }
}

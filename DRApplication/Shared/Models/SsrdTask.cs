using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class SsrdTask
    {
        public SsrdTask()
        {
            IssueSsrdTasks = new HashSet<IssueSsrdTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; } = null!;
        public virtual ICollection<IssueSsrdTask> IssueSsrdTasks { get; set; }
    }
}

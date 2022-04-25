using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            Devices = new HashSet<Device>();
            Drrbs = new HashSet<Drrb>();
            HardwareConfigs = new HashSet<HardwareConfig>();
            RctdLots = new HashSet<RctdLot>();
            SsrdTasks = new HashSet<SsrdTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int MaintainerId { get; set; }
        public bool IsActive { get; set; }

        public virtual Maintainer Maintainer { get; set; } = null!;
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<Drrb> Drrbs { get; set; }
        public virtual ICollection<HardwareConfig> HardwareConfigs { get; set; }
        public virtual ICollection<RctdLot> RctdLots { get; set; }
        public virtual ICollection<SsrdTask> SsrdTasks { get; set; }
    }
}

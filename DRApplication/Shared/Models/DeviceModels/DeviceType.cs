using Dapper.Contrib.Extensions;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Models.TestingModels;
using System;
using System.Collections.Generic;
namespace DRApplication.Shared.Models.DeviceModels
{
    public partial class DeviceType
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public int MaintainerId { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<Device> Devices { get; set; } = new List<Device>();

        //public virtual ICollection<Drrb> Drrbs { get; set; }
        //public virtual ICollection<HardwareConfig> HardwareConfigs { get; set; }
        //public virtual ICollection<RctdLot> RctdLots { get; set; }
        //public virtual ICollection<SsrdTask> SsrdTasks { get; set; }
    }
}

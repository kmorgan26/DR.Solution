using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Models.IssueModels;
using DRApplication.Shared.Models.TestingModels;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.DeviceModels
{
    public partial class Device
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceTypeId { get; set; }
        public bool IsActive { get; set; }


        //public virtual ICollection<DeviceDiscovered> DeviceDiscovereds { get; set; }
        //public virtual ICollection<IssueObserved> IssueObserveds { get; set; }
        //public virtual ICollection<IssuesDevice> IssuesDevices { get; set; }
        //public virtual ICollection<LoadsDevice> LoadsDevices { get; set; }
        //public virtual ICollection<TestEvent> TestEvents { get; set; }
    }
}
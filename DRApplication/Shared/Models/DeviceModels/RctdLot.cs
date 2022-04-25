using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.DeviceModels
{
    public partial class RctdLot
    {
        public RctdLot()
        {
            ManModules = new HashSet<ManModule>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; } = null!;
        public virtual ICollection<ManModule> ManModules { get; set; }
    }
}

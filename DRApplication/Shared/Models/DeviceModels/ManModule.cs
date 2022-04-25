using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.DeviceModels
{
    public partial class ManModule
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RctdLotId { get; set; }

        public virtual RctdLot RctdLot { get; set; } = null!;
    }
}

using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.DeviceModels
{
    [Table("Maintainers")]
    public partial class Maintainer
    {
        //public Maintainer()
        //{
        //    DeviceTypes = new HashSet<DeviceType>();
        //}
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //public virtual ICollection<DeviceType> DeviceTypes { get; set; } = new HashSet<DeviceType>();
    }
}

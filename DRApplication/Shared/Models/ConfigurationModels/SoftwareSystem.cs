using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    [Table("SoftwareSystems")]
    public partial class SoftwareSystem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int HardwareConfigId { get; set; }

    }
}

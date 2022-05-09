using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    [Table("HardwareVersionsConfigs")]
    public partial class HardwareVersionsConfig
    {
        [Key]
        public int Id { get; set; }
        public int HardwareVersionId { get; set; }
        public int HardwareConfigId { get; set; }

    }
}

using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    [Table("HardwareConfigs")]
    public partial class HardwareSystem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}

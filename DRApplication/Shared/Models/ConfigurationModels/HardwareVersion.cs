using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    [Table("HardwareVersions")]
    public partial class HardwareVersion
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int HardwareSystemId { get; set; }
        public DateTime VersionDate { get; set; }
    }
}

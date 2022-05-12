using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    [Table("VersionsLoads")]
    public partial class VersionsLoad
    {
        [Key]
        public int Id { get; set; }
        public int LoadId { get; set; }
        public int SoftwareVersionId { get; set; }

    }
}

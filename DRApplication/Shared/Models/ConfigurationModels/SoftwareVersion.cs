using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    public partial class SoftwareVersion
    {
        public SoftwareVersion()
        {
            VersionsLoads = new HashSet<VersionsLoad>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SoftwareSystemId { get; set; }
        public DateTime? VersionDate { get; set; }

        public virtual SoftwareSystem SoftwareSystem { get; set; } = null!;
        public virtual ICollection<VersionsLoad> VersionsLoads { get; set; }
    }
}

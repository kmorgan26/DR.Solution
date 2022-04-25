using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models.ConfigurationModels
{
    public partial class VersionsLoad
    {
        public int Id { get; set; }
        public int LoadId { get; set; }
        public int SoftwareVersionId { get; set; }

        public virtual Load Load { get; set; } = null!;
        public virtual SoftwareVersion SoftwareVersion { get; set; } = null!;
    }
}

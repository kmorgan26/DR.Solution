using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DRApplication.Shared.Models.DeviceModels
{
    [Table("Maintainers")]
    public partial class Maintainer
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

    }
}

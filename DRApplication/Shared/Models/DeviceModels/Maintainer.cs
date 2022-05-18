using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DRApplication.Shared.Models.DeviceModels
{
    public partial class Maintainer
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<DeviceType> DeviceTypes { get; set; } = new List<DeviceType>();

    }
}

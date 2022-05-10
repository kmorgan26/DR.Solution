using System;
using System.Collections.Generic;
namespace DRApplication.Shared.Models.ConfigurationModels;

public partial class Load
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DeviceTypeId { get; set; }
}

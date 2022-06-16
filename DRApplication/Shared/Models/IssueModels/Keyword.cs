namespace DRApplication.Shared.Models;

public class Keyword
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DeviceTypeId { get; set; }
    public bool DeviceSpecific { get; set; }
}
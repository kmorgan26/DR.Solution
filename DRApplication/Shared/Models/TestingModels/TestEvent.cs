namespace DRApplication.Shared.Models;
public class TestEvent
{
    public int Id { get; set; }
    public DateTime TestEventDate { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DeviceId { get; set; }
    
}
namespace DRApplication.Shared.Models;

public class IssueObserved
{
    public int Id { get; set; }
    public int IssueId { get; set; }
    public int DeviceId { get; set; }
    public DateTime DateObserved { get; set; }
    
}
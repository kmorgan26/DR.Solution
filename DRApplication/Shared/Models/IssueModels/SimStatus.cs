namespace DRApplication.Shared.Models;

public class SimStatus
{
   public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SimStatusTypeId { get; set; }
    public string IssueDisplayName { get; set; } = string.Empty;
    public bool IsActive { get; set; }        
}
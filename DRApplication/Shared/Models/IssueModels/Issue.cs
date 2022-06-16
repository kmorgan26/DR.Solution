namespace DRApplication.Shared.Models;

public class Issue
{
    public int Id { get; set; }
    public int DrTypeId { get; set; }
    public int SimStatusId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
}
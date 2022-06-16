namespace DRApplication.Shared.Models;
public class StatusChange
{
    public int Id { get; set; }
    public int IssueId { get; set; }
    public int SimStatusId { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    public DateTime EnteredDate { get; set; }

}
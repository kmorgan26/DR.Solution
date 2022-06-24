namespace DRApplication.Shared.Models;

public class MaintIssue
{
    public int Id { get; set; }
    public int IssueId { get; set; }
    public string Pid { get; set; } = string.Empty;
    public string ActionTaken { get; set; } = string.Empty;
    public int CorrectiveActionId { get; set; }
}
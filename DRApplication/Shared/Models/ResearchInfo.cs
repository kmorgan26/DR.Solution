namespace DRApplication.Shared.Models;
public class ResearchInfo
{
    public int Id { get; set; }
    public int IssueId { get; set; }
    public DateTime ResearchDate { get; set; }
    public DateTime DeadlineDate { get; set; }
    public string ResearchLead { get; set; } = string.Empty;

}
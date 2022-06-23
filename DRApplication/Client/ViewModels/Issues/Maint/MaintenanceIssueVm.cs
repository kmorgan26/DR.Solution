namespace DRApplication.Client.ViewModels;
public class MaintenanceIssueVm
{
    public int DrTypeId { get; set; }
    public int SimStatusId { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;


    public string Pid { get; set; } = string.Empty;
    public int CorrectiveActionId { get; set; } = 0;

}

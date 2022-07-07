namespace DRApplication.Client.ViewModels;

public class MaintenanceIssueInsertVm
{
    public bool IsDeferred { get; set; } = false;
    public bool IsContractor { get; set; } = false;
    public string Description { get; set; } = string.Empty;
    public DateTime? IssueDate { get; set; } = DateTime.Today;
    public string EnteredBy { get; set; } = string.Empty;
    public int DeviceId { get; set; }
    public string Pid { get; set; } = string.Empty;
    public string ActionTaken { get; set; } = string.Empty;
    public int CorrectiveActionId { get; set; } = 0;
}
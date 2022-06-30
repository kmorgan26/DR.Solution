using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels;
public class MaintenanceIssueInsertVm
{
    public bool IsDeferred { get; set; } = false;

    public bool IsContractor { get; set; } = false;

    [Required]
    public string Description { get; set; } = string.Empty;

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime? IssueDate { get; set; } = DateTime.Today;

    public string EnteredBy { get; set; } = string.Empty;

    [Required]
    public int DeviceId { get; set; }

    [Required]
    public string Pid { get; set; } = string.Empty;

    [Required]
    public string ActionTaken { get; set; } = string.Empty;

    public int CorrectiveActionId { get; set; } = 0;
}

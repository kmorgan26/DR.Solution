using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels;
public class MaintenanceIssueInsertVm
{
    public int DrTypeId { get; set; }
    public int SimStatusId { get; set; } = 0;

    [Required]
    public string Description { get; set; } = string.Empty;

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime? IssueDate { get; set; } = DateTime.Today;

    public string EnteredBy { get; set; } = string.Empty;

    [Required]
    public int DeviceId { get; set; }

    [Required]
    public string Pid { get; set; } = string.Empty;


    public int CorrectiveActionId { get; set; } = 0;
}

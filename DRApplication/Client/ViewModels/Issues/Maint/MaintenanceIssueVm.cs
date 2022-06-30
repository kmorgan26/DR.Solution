using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels;
public class MaintenanceIssueVm
{
    public int IssueId { get; set; } = 0;

    [Display(Name="Type")]
    public string DrType { get; set; } = string.Empty;
    
    [Display(Name="Status")]
    public string SimStatus { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [Display(Name="Issue Date")]
    public DateTime IssueDate { get; set; }

    [Display(Name ="Entered By")]
    public string EnteredBy { get; set; } = string.Empty;

    [Display(Name ="PID")]
    public string Pid { get; set; } = string.Empty;

    public string Device { get; set; } = string.Empty;

    [Display(Name ="Corrective Action")]
    public string CorrectiveAction { get; set; } = string.Empty;

    [Display(Name ="Action Taken")]
    public string ActionTaken { get; set; } = string.Empty;

}

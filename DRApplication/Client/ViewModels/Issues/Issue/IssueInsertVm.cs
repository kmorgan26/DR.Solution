namespace DRApplication.Client.ViewModels;
public class IssueInsertVm
{
    public int DrTypeId { get; set; } = 0;
    public int SimStatusId { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
}
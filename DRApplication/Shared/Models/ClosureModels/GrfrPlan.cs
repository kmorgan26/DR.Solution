namespace DRApplication.Shared.Models;
public class GrfrPlan
{
    public int Id { get; set; } = 0;
    public int DrId { get; set; } = 0;
    public DateTime GrfrDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    public DateTime EnteredDate { get; set; }
}
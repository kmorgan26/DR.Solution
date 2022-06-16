namespace DRApplication.Shared.Models;
public class GrfrHistory
{
    public int Id { get; set; } = 0;
    public int DrId { get; set; } = 0;
    public DateTime GrfrDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    public DateTime EnteredDate { get; set; }
}
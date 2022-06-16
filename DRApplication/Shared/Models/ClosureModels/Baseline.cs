namespace DRApplication.Shared.Models;

public class Baseline
{
    public int Id { get; set; } = 0;
    public DateTime BaseLineDate { get; set; }
    public int DrId { get; set; } = 0;
    public DateTime EnteredDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
}
namespace DRApplication.Shared.Models;

public class UserLog
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public DateTime LoginDateTime { get; set; }
    public bool IsSuccess { get; set; }
}
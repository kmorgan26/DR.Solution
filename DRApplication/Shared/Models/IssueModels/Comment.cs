namespace DRApplication.Shared.Models;
public class Comment
{
    public int Id { get; set; }
    public int IssueId { get; set; }
    public string CommentText { get; set; } = string.Empty;
    public DateTime CommentDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;

}

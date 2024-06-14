namespace ProjectManagement.Models;

public class Project
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime BeganAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsSubproject { get; set; }
    public long ParentId { get; set; }
    public long UserId { get; set; }
}
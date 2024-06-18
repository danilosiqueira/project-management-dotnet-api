namespace ProjectManagement.Api.Models;

public class Project
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime BeganAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsSubproject { get; set; }
    public long? ParentId { get; set; }
    public long UserId { get; set; }
}
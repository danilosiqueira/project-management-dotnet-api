namespace ProjectManagement.Api.Models;

public class ProjectIn
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime BeganAt { get; set; }
    public bool IsSubproject { get; set; }
    public long? ParentId { get; set; }
}
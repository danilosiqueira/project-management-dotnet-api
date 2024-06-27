namespace ProjectManagement.Api.Models;

public class Task
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime BeganAt { get; set; }
    public DateTime DoneAt { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsDone { get; set; }
    public long ProjectId { get; set; }
    public long? AssignedTo { get; set; }
    public long UserId { get; set; }
}
namespace ProjectManagement.Models;

public class User
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public DateTime CreatedAt { get; set; }
}
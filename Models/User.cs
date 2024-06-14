namespace ProjectManagement.Models;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
}
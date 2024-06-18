namespace ProjectManagement.Api.Business;

public class Validation
{
    public string Message { get; }

    public Validation(string message)
    {
        Message = message;
    }
}
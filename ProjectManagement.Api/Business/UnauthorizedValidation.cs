namespace ProjectManagement.Api.Business;

public class UnauthorizedValidation
{
    public string Message { get; }

    public UnauthorizedValidation(string message)
    {
        Message = message;
    }
}
namespace ProjectManagement.Api.Business;

public class RequestContext : IRequestContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RequestContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public long GetUserId()
    { 
        var userId = _httpContextAccessor?.HttpContext?.Items["UserId"];

        if (userId is null)
            throw new ApplicationException("User id cannot be recovered.");

        return (long) userId;
    }
}
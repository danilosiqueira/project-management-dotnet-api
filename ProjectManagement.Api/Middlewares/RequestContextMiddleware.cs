using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace ProjectManagement.Api.Middlewares;

public class RequestContextMiddleware
{
    private readonly RequestDelegate _next;

    public RequestContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var userIdClaim = httpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim is not null)
            httpContext.Items["UserId"] = long.Parse(userIdClaim);

        await _next(httpContext);
    }
}

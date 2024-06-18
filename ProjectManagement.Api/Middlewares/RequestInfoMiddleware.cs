using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace ProjectManagement.Api.Middlewares;

public class RequestInfoMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly RequestInfo _requestInfo;

    public RequestInfoMiddleware(
        RequestDelegate next, 
        ILogger<ExceptionHandlingMiddleware> logger,
        RequestInfo requestInfo)
    {
        _next = next;
        _logger = logger;
        _requestInfo = requestInfo;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var userIdClaim = httpContext.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        if (userIdClaim is not null)
            _requestInfo.UserId = long.Parse(userIdClaim);

        await _next(httpContext);
    }
}

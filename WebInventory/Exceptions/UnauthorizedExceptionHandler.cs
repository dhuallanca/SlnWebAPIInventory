using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebInventory.Exceptions
{
    public class UnauthorizedExceptionHandler(ILogger<UnauthorizedExceptionHandler> _logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not UnauthorizedAccessException unauthorizedAccessException)
            {
                return false;
            }
            _logger.LogError(exception, "Exception Message: {Message}, Time of occurrence {Time}", unauthorizedAccessException.Message, DateTime.UtcNow);
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "User Unauthorized",
                Detail = unauthorizedAccessException.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TodoAppApi.Middleware
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception,
        CancellationToken cancellation)
        {
            _logger.LogError(exception, "An error occurred while processing the request");
            ProblemDetails problemDetails = new()
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError
            };
            await context.Response.WriteAsJsonAsync(problemDetails, cancellation);
            return true;
        }
    }

}

using System.Diagnostics;

namespace TodoAppApi.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("request connection Id: {id}",context.Connection.Id);
            _logger.LogInformation("request Method:{method}", context.Request.Method);
            _logger.LogInformation("request Porotocol:{porotocol}", context.Request.Protocol);
            _logger.LogInformation("request path:{path}", context.Request.Path);
            _logger.LogInformation("request Headeres{headers}",context.Request.Headers);
            _logger.LogInformation("request Method:{method}", context.Request.QueryString);
            _logger.LogInformation("request RemoteIpAddress:{RemoteIpAddress}", context.Connection.RemoteIpAddress);




            await _next(context);



            _logger.LogInformation("hallo nachher");
            _logger.LogInformation("response Headers{headers}", context.Response.Headers);

        }
    }
}

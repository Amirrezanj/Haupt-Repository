using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TodoAppApi.Filter
{
    public class LoggingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
            base.OnActionExecuted(context);

            Debug.WriteLine($"logging filter path : {context.HttpContext.Request.Path}");
        }
    }
}
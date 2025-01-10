using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace TodoAppApi.Filter
{
    public class CachingFilter : Attribute, IResourceFilter
    {


        //private readonly IMemoryCache _cache;
        //public CachingFilter(IMemoryCache cache) 
        //{
        //    _cache = cache;
        //}
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var cache = context.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();

            if (cache.TryGetValue(context.HttpContext.Request.Path,out IActionResult? value))
            {
                context.Result = value;
            }
        }


        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var cache =context.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
            cache.Set(context.HttpContext.Request.Path, context.Result,TimeSpan.FromMinutes(5));
        }

    }
}

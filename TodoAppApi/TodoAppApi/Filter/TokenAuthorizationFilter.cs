using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TodoAppApi.Collections;
using TodoAppApi.Data;

namespace TodoAppApi.Filter
{
    public class TokenAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private string? _role;
        public TokenAuthorizationFilter(string? role)
        {
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers.Authorization.ToString();

            if (string.IsNullOrWhiteSpace(token))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new EmptyResult();
                return;
            }


            if (!token.StartsWith("Bearer "))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new EmptyResult();
                return;
            }
            token = token.Substring("Bearer ".Length);
            //token = token.Substring(7);

            var dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
            var user = dbContext.Users.SingleOrDefault(x => x.SessionToken != null && x.TokenExpiry != null && x.SessionToken == token && x.TokenExpiry > DateTime.UtcNow);
            if (user == null)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new EmptyResult();
                return;
            }

            if (!string.IsNullOrWhiteSpace(_role) && user.Role.ToString() != _role)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Result = new EmptyResult();
                return;
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            var identity = new ClaimsIdentity(claims , "SessionId");
            context.HttpContext.User = new ClaimsPrincipal(identity);

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TodoAppApi.Data;
using TodoAppApi.Filter;
using TodoAppApi.Helpers;
using TodoAppApi.Models.Requests;
using TodoAppApi.Models.Responses;

namespace TodoAppApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public SessionController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CreateSessionResponse>> CreateSessionAsync(CreateSessionRequest request)
        {
            var user = _dbcontext.Users.SingleOrDefault(x => x.Email == request.Email);

            if (user == null)
                return Unauthorized();

            if (!PasswordHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            var token = TokenHelper.GenerateToken();
            var expiry = DateTime.UtcNow.AddHours(2);

            user.SessionToken = token;
            user.TokenExpiry = expiry;
            await _dbcontext.SaveChangesAsync();
            return Ok(CreateSessionResponse.FromEntity(user));
        }

        [HttpDelete("current")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [TokenAuthorizationFilter]
        public async Task<IActionResult> DeleteSessionAsync()
        {
            // statt komentare haben wir filter geschrieben
            //var token = HttpContext.Request.Headers.Authorization.ToString();

            //if(string.IsNullOrWhiteSpace(token))return Unauthorized();

            //if(!token.StartsWith("Bearer ")) return Unauthorized();
            //token = token.Substring("Bearer ".Length);
            ////token = token.Substring(7);

            //var user = _dbcontext.Users.SingleOrDefault(x =>x.SessionToken!=null && x.TokenExpiry!=null && x.SessionToken == token && x.TokenExpiry > DateTime.UtcNow) ;
            //if (user == null) return Unauthorized();


            var userId = HttpContext.User.Claims.Single(x=>x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _dbcontext.Users.Single(x=>x.Id==Guid.Parse(userId));

            user.TokenExpiry = null;
            user.SessionToken = null;

            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TodoAppApi.Collections;
using TodoAppApi.Data;
using TodoAppApi.Filter;
using TodoAppApi.Models.Responses;

namespace TodoAppApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly ILogger<AdminController> _logger;
        
        public AdminController(ApplicationDbContext dbContext, ILogger<AdminController> logger)
        {
            _dbcontext = dbContext;
            _logger = logger;
        }
        [HttpGet("users")]
        [TokenAuthorizationFilter("Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<IEnumerable<GetUserResponse>> GetAllUsers([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
        {
            var users = _dbcontext.Users.Skip(page*pageSize).Take(pageSize).ToList();
            return Ok(users.Select(x=>GetUserResponse.FromEntity(x)));
        }

    }
}

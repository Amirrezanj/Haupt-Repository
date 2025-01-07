using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAppApi.Data;
using TodoAppApi.Data.Entities;
using TodoAppApi.Models.Requests;
using TodoAppApi.Models.Responses;

namespace TodoAppApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public UsersController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GetUserResponse>> GetUsers()
        {
            var users = new List<GetUserResponse>();
            foreach (var user in _dbcontext.Users)
            {
                users.Add(GetUserResponse.FromEntity(user));
            }
            return Ok(users);
        }
        [HttpGet("{id}/address")]
        [Produces("application/json")]
        public ActionResult<GetUserAddressResponse> GetAddressForUser(Guid id)
        {
            var addresse = _dbcontext.Users.Include(x => x.Address).FirstOrDefault(x => x.Id == id).Address;
            if (addresse == null) return NotFound();
            return Ok(GetUserAddressResponse.FromEntity(addresse));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GetUserResponse> GetUser(Guid id)
        {
            var item = _dbcontext.Users.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(GetUserResponse.FromEntity(item));
        }
    }
}
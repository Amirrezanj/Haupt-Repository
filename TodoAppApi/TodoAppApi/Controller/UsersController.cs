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
        private readonly ILogger<UsersController> _logger;

        public UsersController(ApplicationDbContext dbContext,ILogger<UsersController> logger)
        {
            _dbcontext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GetUserResponse>> GetUsers(int page=0 , int pageSize=10)
        {
            _logger.LogInformation("GetUsers was called");

            var users = _dbcontext.Users.Skip(page * pageSize).Take(pageSize);

            return Ok(users.Select(x=>GetUserResponse.FromEntity(x)));



            //var users = new List<GetUserResponse>();
            //foreach (var user in _dbcontext.Users)
            //{
            //    users.Add(GetUserResponse.FromEntity(user));
            //}
            //return Ok(users);
        }
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GetUserResponse> GetUser(Guid id)
        {
            _logger.LogInformation("GetUserById was called with Id {id}", id);

            var item = _dbcontext.Users.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(GetUserResponse.FromEntity(item));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest request)
        {
            var entity = CreateUserRequest.ToEntity(request);

            _dbcontext.Users.Add(entity);
            await _dbcontext.SaveChangesAsync();

            return Created($"/users/{entity.Id}", CreateUserResponse.FromEntity(entity));
        }

        [HttpGet("{id}/address")]
        [Produces("application/json")]
        public ActionResult<GetUserAddressResponse> GetAddressForUser(Guid id)
        {
            var addresse = _dbcontext.Users.Include(x => x.Address)
            .FirstOrDefault(x => x.Id == id).Address;
            if (addresse == null) return NotFound();
            return Ok(GetUserAddressResponse.FromEntity(addresse));
        }

    }
}
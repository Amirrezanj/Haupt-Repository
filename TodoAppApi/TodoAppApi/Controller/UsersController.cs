using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using TodoAppApi.Data;
using TodoAppApi.Data.Entities;
using TodoAppApi.Filter;
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
        //private readonly IMemoryCache _cache;

        public UsersController(ApplicationDbContext dbContext,ILogger<UsersController> logger /*,IMemoryCache cache*/)
        {
            _dbcontext = dbContext;
            _logger = logger;
            //_cache = cache;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest request)
        {
            var entity = CreateUserRequest.ToEntity(request);

            _dbcontext.Users.Add(entity);
            await _dbcontext.SaveChangesAsync();

            return Created($"/users/current", CreateUserResponse.FromEntity(entity));
        }










        [HttpGet("current")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [TokenAuthorizationFilter("User")]
        public ActionResult<GetUserResponse> GetCurrentUser()
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var entity = _dbcontext.Users.Single(x => x.Id == Guid.Parse(userId));

            return Ok(GetUserResponse.FromEntity(entity));
        }









        [HttpPut("current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TokenAuthorizationFilter("User")]

        public async Task<ActionResult<UpdateUserResponse>> UpdateCurrentUser(UpdateUserRequest request)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _dbcontext.Users.Single(x => x.Id == Guid.Parse(userId));

            user.FirstName = request.FirstName;
            user.SecondName = request.SecondName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            await _dbcontext.SaveChangesAsync();

            return Ok(UpdateUserResponse.FromEntity(user));
        }


        [HttpDelete("current")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [TokenAuthorizationFilter("User")]
        public async Task<ActionResult> DeleteCurrentUser()
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _dbcontext.Users.Include(x => x.Todos).Single(x => x.Id == Guid.Parse(userId));

            if (user.Todos.Count != 0)
                return Conflict("Can not delete user if todos are left.");

            _dbcontext.Remove(user);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }
        //alte version
        //[HttpGet]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[LoggingFilter]
        //[CachingFilter]
        //[TokenAuthorizationFilter]
        //public ActionResult<IEnumerable<GetUserResponse>> GetUsers(int page = 0, int pageSize = 10)
        //{
        //    _logger.LogInformation("GetUsers was called");

        //    var users = _dbcontext.Users.Skip(page * pageSize).Take(pageSize).ToList();

        //    return Ok(users.Select(x => GetUserResponse.FromEntity(x)));



        //    //var users = new List<GetUserResponse>();
        //    //foreach (var user in _dbcontext.Users)
        //    //{
        //    //    users.Add(GetUserResponse.FromEntity(user));
        //    //}
        //    //return Ok(users);
        //}
        //[HttpGet("{id}")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<GetUserResponse> GetUser(Guid id)
        //{
        //    _logger.LogInformation("GetUserById was called with Id {id}", id);

        //    var item = _dbcontext.Users.FirstOrDefault(x => x.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(GetUserResponse.FromEntity(item));
        //}


       

        [HttpGet("current/address")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [TokenAuthorizationFilter("User")]
        public ActionResult<GetUserAddressResponse> GetAddressForCurrentUser()
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _dbcontext.Users.Include(x => x.Address).Single(x => x.Id == Guid.Parse(userId));

            return Ok(GetUserAddressResponse.FromEntity(user.Address));
        }








        [HttpPut("current/address")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TokenAuthorizationFilter("User")]
        public async Task<ActionResult<UpdateAddressResponse>> UpdateUserAddressAsync(UpdateAddressRequest request)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _dbcontext.Users.Include(x => x.Address).Single(x => x.Id == Guid.Parse(userId));

            user.Address.Street = request.Street;
            user.Address.HouseNumber = request.HouseNumber;
            user.Address.City = request.City;
            user.Address.Country = request.Country;
            user.Address.ZipCode = request.ZipCode;

            await _dbcontext.SaveChangesAsync();
            return Ok(UpdateAddressResponse.FromEntity(user.Address));
        }








        [HttpPost("current/todos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TokenAuthorizationFilter("User")]
        public async Task<ActionResult<CreateTodoResponse>> CreateTodoItem(CreateTodoRequest request)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _dbcontext.Users.Single(x => x.Id == Guid.Parse(userId));

            var entity = CreateTodoRequest.ToEntity(request);

            user.Todos.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return Created($"/users/current/todoitems/{entity.Id}", CreateTodoResponse.FromEntity(entity));
        }








        [HttpGet("current/todos")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [TokenAuthorizationFilter("User")]
        public ActionResult<IEnumerable<GetTodoResponse>> GetTodoItems(
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? titleFilter = null)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;

            //IQueryable<TodoEntity> todoItems = _dbcontext.Todos.Where(x => x.Id == Guid.Parse(userId));
            IEnumerable<TodoEntity> todoItems = _dbcontext.Users.Include(x => x.Todos).First(x => x.Id == Guid.Parse(userId)).Todos;

            if (!string.IsNullOrWhiteSpace(titleFilter))
            {
                todoItems = todoItems.Where(x => x.Title.Contains(titleFilter));
            }

            todoItems = todoItems.Skip(page * pageSize).Take(pageSize);

            return Ok(todoItems.Select(x => GetTodoResponse.FromEntity(x)));
        }






        [HttpGet("current/todos/{todoId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TokenAuthorizationFilter("User")]
        public ActionResult<GetTodoResponse> GetTodoItemById(Guid todoId)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var todo = _dbcontext.Todos.SingleOrDefault(x => x.Id == todoId && x.Id == Guid.Parse(userId));

            if (todo == null)
                return NotFound();

            return Ok(GetTodoResponse.FromEntity(todo));
        }









        [HttpPut("current/todos/{todoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TokenAuthorizationFilter("User")]
        public async Task<ActionResult<UpdateTodoResponse>> UpdateTodoItemAsync(UpdateTodoRequest request, Guid todoId)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var todo = _dbcontext.Todos.SingleOrDefault(x => x.Id == todoId && x.Id == Guid.Parse(userId));

            if (todo == null)
                return NotFound();

            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.DueDate = request.DueDate;
            todo.IsDone = request.IsDone;

            await _dbcontext.SaveChangesAsync();
            return Ok(CreateTodoResponse.FromEntity(todo));
        }





        [HttpDelete("current/todos/{todoId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TokenAuthorizationFilter("User")]
        public async Task<ActionResult> DeleteTodoItemByIdAsync(Guid todoId)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var todo = _dbcontext.Todos.SingleOrDefault(x => x.Id == todoId && x.Id == Guid.Parse(userId));

            if (todo == null)
                return NotFound();

            _dbcontext.Remove(todo);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }

    }
}
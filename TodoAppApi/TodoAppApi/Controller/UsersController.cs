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
        private readonly IMemoryCache _cache;

        public UsersController(ApplicationDbContext dbContext,ILogger<UsersController> logger ,IMemoryCache cache)
        {
            _dbcontext = dbContext;
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [LoggingFilter]
        [CachingFilter]
        [TokenAuthorizationFilter]
        public ActionResult<IEnumerable<GetUserResponse>> GetUsers(int page=0 , int pageSize=10)
        {
            _logger.LogInformation("GetUsers was called");

            var users = _dbcontext.Users.Skip(page * pageSize).Take(pageSize).ToList();

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]

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

            _cache.Remove("/Users");

            return Created($"/users/{entity.Id}", CreateUserResponse.FromEntity(entity));
        }


        [HttpGet("{id}/address")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetUserAddressResponse> GetAddressForUser(Guid id)
        {
            var entity = _dbcontext.Users.Include(x => x.Address)
            .FirstOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            return Ok(GetUserAddressResponse.FromEntity(entity.Address));
        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> DeleteUserByIdAsync(Guid id)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            if (_dbcontext.Todos.Where(x => x.Id == user.Id).Any())
                return Conflict("Can not delete user if todos are left.");

            _dbcontext.Remove(user);


            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUserAsync(UpdateUserRequest request, Guid userId)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return NotFound();

            user.FirstName = request.FirstName;
            user.SecondName = request.SecondName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            await _dbcontext.SaveChangesAsync();

            _cache.Remove("/Users");

            return Ok(UpdateUserResponse.FromEntity(user));
        }


        [HttpPut("Address")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateAddressResponse>> UpdateUserAddressAsync(UpdateAddressRequest request, Guid userId)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return NotFound();

            var address = _dbcontext.Addresses.FirstOrDefault(x => x.Id == request.Id);

            if (address == null)
                return NotFound();

            address.Street = request.Street;
            address.HouseNumber = request.HouseNumber;
            address.City = request.City;
            address.Country = request.Country;
            address.ZipCode = request.ZipCode;

            _cache.Remove("/Users");

            await _dbcontext.SaveChangesAsync();
            return Ok(UpdateAddressResponse.FromEntity(address));
        }
        [HttpGet("current/Todoitems")] // wenn jemend get methode aufruft landmal hier
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [TokenAuthorizationFilter]
        public ActionResult<IEnumerable<GetTodoResponse>> GetTodoItems(int page = 0, int pageSize = 10, string? titleFilter = null)
        {
            //zwei zeilen von vincent copiert
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            IEnumerable<TodoEntity> todoItems = _dbcontext.Users.Include(x => x.Todos).First(x => x.Id == Guid.Parse(userId)).Todos;


            if (!string.IsNullOrWhiteSpace(titleFilter))
            {
                todoItems = todoItems.Where(x => x.Title.Contains(titleFilter));
            }

            todoItems = todoItems.Skip(page * pageSize).Take(pageSize);

            return Ok(todoItems.Select(x => GetTodoResponse.FromEntity(x)));

            //var list = new List<GetTodoResponse>();
            //foreach (var item in _dbcontext.Todos)
            //{
            //    list.Add(GetTodoResponse.FromEntity(item));
            //}

            //return Ok(list);

            //Alternative
            //return Ok(_dbcontext.Todos.Select(x => GetTodoResponse.FromEntity(x)));
        }

        [HttpGet("current/TodosItems/{todoId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [TokenAuthorizationFilter]
        public ActionResult<GetTodoResponse> GetTodoItem(Guid todoId)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var todoItem = _dbcontext.Users.Include(x => x.Todos).First(x => x.Id == Guid.Parse(userId)).Todos.First(x=>x.Id == todoId);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(GetTodoResponse.FromEntity(todoItem));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        [TokenAuthorizationFilter]
        public async Task<ActionResult<CreateTodoResponse>> CreateTodoItem(CreateTodoRequest request)
        {
            //wurde kommentiert durch wir ein parameter in der klmmer geschrieben haben zwar TodoEntity.
            //TodoEntity? entity= await HttpContext.Request.ReadFromJsonAsync<TodoEntity>();
            //if (entity == null) return BadRequest("Invalid TodoItem");



            //um ein todo item zu legen brauchen wir erst ein user
            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _dbcontext.Users.Single(x => x.Id == Guid.Parse(userId));

            if (user == null) return NotFound();

            var entity = CreateTodoRequest.ToEntity(request);
            //TEMP
            //entity.User = new UserEntity
            //{
            //    FirstName = "amir",
            //    LastName = "mj",
            //    Email = "blallala@gmail.com",
            //    Address = new AddressEntity
            //    {
            //        Street = "harzstrasse",
            //        HouseNumber = "26",
            //        City = "heiligenhaus",
            //        Country = "germany",
            //        ZipCode = "E G A L"
            //    }
            //};
            user.Todos.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return Created($"/todoitems/{entity.Id}", CreateTodoResponse.FromEntity(entity));
        }
    }
}
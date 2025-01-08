using Microsoft.AspNetCore.Mvc;
using TodoAppApi.Data;
using TodoAppApi.Data.Entities;
using TodoAppApi.Models.Requests;
using TodoAppApi.Models.Responses;

namespace TodoAppApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly ILogger<UsersController> _logger;

        public TodoItemsController(ApplicationDbContext dbcontext,ILogger<UsersController>logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GetTodoResponse>> GetTodoItems(int page =0,int pageSize=10,string? titleFilter=null)
        {
            if (titleFilter!=null)
            {
                var todoItems = _dbcontext.Todos.Where(x=>x.Title.Contains(titleFilter));
                return Ok(todoItems.Select(x=>GetTodoResponse.FromEntity(x)));

            }
            else 
            {
                var todoItems = _dbcontext.Todos.Skip(page * pageSize).Take(pageSize);
                return Ok(todoItems.Select(x => GetTodoResponse.FromEntity(x)));
            }

            //var list = new List<GetTodoResponse>();
            //foreach (var item in _dbcontext.Todos)
            //{
            //    list.Add(GetTodoResponse.FromEntity(item));
            //}

            //return Ok(list);

            //Alternative
            //return Ok(_dbcontext.Todos.Select(x => GetTodoResponse.FromEntity(x)));
        }




        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetTodoResponse> GetTodoItem(Guid id)
        {
            var item = _dbcontext.Todos.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(GetTodoResponse.FromEntity(item));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreateTodoResponse>> CreateTodoItem(CreateTodoRequest request)
        {
            //wurde kommentiert durch wir ein parameter in der klmmer geschrieben haben zwar TodoEntity.
            //TodoEntity? entity= await HttpContext.Request.ReadFromJsonAsync<TodoEntity>();
            //if (entity == null) return BadRequest("Invalid TodoItem");

            var entity = CreateTodoRequest.ToEntity(request);
            //TEMP
            entity.User = new UserEntity
            {
                FirstName = "amir",
                LastName = "mj",
                Email = "blallala@gmail.com",
                Address = new AddressEntity
                {
                    Street = "harzstrasse",
                    HouseNumber = "26",
                    City = "heiligenhaus",
                    Country = "germany",
                    ZipCode = "E G A L"
                }
            };
            _dbcontext.Todos.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return Created($"/todoitems/{entity.Id}", CreateTodoResponse.FromEntity(entity));
        }
    }
}
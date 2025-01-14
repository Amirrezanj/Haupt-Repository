//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;
//using TodoAppApi.Data;
//using TodoAppApi.Data.Entities;
//using TodoAppApi.Filter;
//using TodoAppApi.Models.Requests;
//using TodoAppApi.Models.Responses;

//namespace TodoAppApi.Controller
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class TodoItemsController : ControllerBase
//    {
//        private readonly ApplicationDbContext _dbcontext;
//        private readonly ILogger<UsersController> _logger;

//        public TodoItemsController(ApplicationDbContext dbcontext,ILogger<UsersController>logger)
//        {
//            _dbcontext = dbcontext;
//            _logger = logger;
//        }

//        [HttpGet("current/Todoitems")] // wenn jemend get methode aufruft landmal hier
//        [Produces("application/json")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [TokenAuthorizationFilter]
//        public ActionResult<IEnumerable<GetTodoResponse>> GetTodoItems(int page =0,int pageSize=10,string? titleFilter=null)
//        {
//            //zwei zeilen von vincent copiert
//            var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
//            IEnumerable<TodoEntity> todoItems = _dbcontext.Users.Include(x => x.Todos).First(x => x.Id == Guid.Parse(userId)).Todos;


//            if (!string.IsNullOrWhiteSpace(titleFilter))
//            {
//                todoItems = todoItems.Where(x => x.Title.Contains(titleFilter));
//            }

//            todoItems = todoItems.Skip(page * pageSize).Take(pageSize);

//            return Ok(todoItems.Select(x => GetTodoResponse.FromEntity(x)));

//            //var list = new List<GetTodoResponse>();
//            //foreach (var item in _dbcontext.Todos)
//            //{
//            //    list.Add(GetTodoResponse.FromEntity(item));
//            //}

//            //return Ok(list);

//            //Alternative
//            //return Ok(_dbcontext.Todos.Select(x => GetTodoResponse.FromEntity(x)));
//        }



//        [HttpGet("{id}")]
//        [Produces("application/json")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public ActionResult<GetTodoResponse> GetTodoItem(Guid id)
//        {
//            var item = _dbcontext.Todos.FirstOrDefault(x => x.Id == id);
//            if (item == null)
//            {
//                return NotFound();
//            }

//            return Ok(GetTodoResponse.FromEntity(item));
//        }




//        //public async Task<ActionResult<PutTodoResponse>> PutTodoItem(PutTodoRequest request, Guid id)
//        //{

//        //}






//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult<CreateTodoResponse>> CreateTodoItem(CreateTodoRequest request,Guid userId)
//        {
//            //wurde kommentiert durch wir ein parameter in der klmmer geschrieben haben zwar TodoEntity.
//            //TodoEntity? entity= await HttpContext.Request.ReadFromJsonAsync<TodoEntity>();
//            //if (entity == null) return BadRequest("Invalid TodoItem");



//            //um ein todo item zu legen brauchen wir erst ein user
//            var user = _dbcontext.Users.FirstOrDefault(x => x.Id == userId);
//            if (user == null) return NotFound();

//            var entity = CreateTodoRequest.ToEntity(request);
//            //TEMP
//            //entity.User = new UserEntity
//            //{
//            //    FirstName = "amir",
//            //    LastName = "mj",
//            //    Email = "blallala@gmail.com",
//            //    Address = new AddressEntity
//            //    {
//            //        Street = "harzstrasse",
//            //        HouseNumber = "26",
//            //        City = "heiligenhaus",
//            //        Country = "germany",
//            //        ZipCode = "E G A L"
//            //    }
//            //};
//            user.Todos.Add(entity);
//            await _dbcontext.SaveChangesAsync();
//            return Created($"/todoitems/{entity.Id}", CreateTodoResponse.FromEntity(entity));
//        }

//        [HttpDelete]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult> DeleteTodoItemByIdAsync(Guid id)
//        {
//            var todo = _dbcontext.Todos.FirstOrDefault(x => x.Id == id);

//            if (todo == null)
//                return NotFound();

//            _dbcontext.Remove(todo);
//            await _dbcontext.SaveChangesAsync();
//            return NoContent();
//        }

//        [HttpPut]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult<UpdateTodoResponse>> UpdateTodoItemAsync(UpdateTodoRequest request, Guid userId)
//        {
//            var user = _dbcontext.Users.FirstOrDefault(x => x.Id == userId);

//            if (user == null)
//                return NotFound();

//            var todo = _dbcontext.Todos.FirstOrDefault(x => x.Id == request.Id);

//            if (todo == null)
//                return NotFound();

//            todo.Title = request.Title;
//            todo.Description = request.Description;
//            todo.DueDate = request.DueDate;
//            todo.IsDone = request.IsDone;

//            await _dbcontext.SaveChangesAsync();
//            return Ok(CreateTodoResponse.FromEntity(todo));
//        }
//    }
//}
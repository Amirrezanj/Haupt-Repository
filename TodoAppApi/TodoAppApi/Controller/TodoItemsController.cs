using Microsoft.AspNetCore.Mvc;
using TodoAppApi.Data;
using TodoAppApi.Data.Entities;

namespace TodoAppApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public TodoItemsController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TodoEntity>> GetTodoItems()
        {
            return Ok(_dbcontext.Todos);
        }
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<string> GetTodoItem(Guid id)
        {
            var item = _dbcontext.Todos.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}

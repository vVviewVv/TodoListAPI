using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        //private static List<TodoList> list = new List<TodoList>
        //    {
        //        new TodoList {
        //            Id = 1,
        //            Tlist = "test",
        //            IsComplete = true,
        //            DateAdd = DateTime.Now,
        //            DueDate = DateTime.Now
        //        },
        //        new TodoList {
        //            Id = 2,
        //            Tlist = "view",
        //            IsComplete = true,
        //            DateAdd = DateTime.Now,
        //            DueDate = DateTime.Now
        //        },
        //    };

        //private readonly DataContext _context;

        //public TodoListController(DataContext Context)
        //{
        //    _context = Context;
        //}

        private readonly ITodoService _todoService;

        public TodoListController(ITodoService todoService)
        {
            _todoService = todoService;
        }


        // GET: api/<TodoListController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoList()
        {
            return await _todoService.GetTodoList();
        }

        // GET api/<TodoListController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> Get(int id)
        {
            var todoItems = await _todoService.GetTodoList(id);
            if (todoItems == null)
                return BadRequest("Not found.");
            return Ok(todoItems);
        }

        // POST api/<TodoListController>
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoItem([FromBody] TodoList todoItem)
        {
            return await _todoService.CreateList(todoItem);
        }


        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoList>> PutTodoItems(int id, [FromBody] TodoList todoItems)
        {
            return Ok(await _todoService.UpdateList(id, todoItems));
        }

        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoList>> DeleteTodoList(int id)
        {
            return Ok(await _todoService.DeleteList(id));
        }
    }
}

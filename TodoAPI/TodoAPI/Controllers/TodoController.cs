using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;
using Todo.Domain;
using Microsoft.AspNetCore.OData.Query;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var todos = await _todoService.GetTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItems todo)
        {
            var id = await _todoService.AddTodoAsync(todo);
            return CreatedAtAction(nameof(GetById), new { id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoItems todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            await _todoService.UpdateTodoAsync(todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }
    }
}

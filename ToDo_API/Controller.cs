using Microsoft.AspNetCore.Mvc;
using TodoApi.Model;
using TodoApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Controllers
{
    [ApiController]
    [Route("[api/contoller]")]
    class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetAll()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetById(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
                return NotFound();
            return todo;
        }

        [HttpPost]
        public async Task<ActionResult<TodoModel>> Create(TodoModel todo)
        {
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoModel>> Update(int id, TodoModel updatedTodo)
        {
            if (id != updatedTodo.Id)
            {
                return BadRequest();
            }

            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.Body = updatedTodo.Body;
            todo.IsCompleted = updatedTodo.IsCompleted;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<TodoModel>> Delete(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
                return NotFound();
            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
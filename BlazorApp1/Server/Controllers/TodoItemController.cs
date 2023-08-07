using BlazorApp1.Server.Data;
using BlazorApp1.Shared;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TodoItemController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _context.TodoItems.ToListAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var todo = await _context.TodoItems.FirstOrDefaultAsync(a => a.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoItem todoItem)
        {
            _context.Add(todoItem);
            await _context.SaveChangesAsync();
            return Ok(todoItem.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.TodoItems.FirstOrDefaultAsync(a => a.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

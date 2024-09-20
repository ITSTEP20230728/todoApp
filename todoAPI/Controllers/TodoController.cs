using Microsoft.AspNetCore.Mvc ;
using Microsoft.EntityFrameworkCore ;
using System.Linq ;
using System.Threading.Tasks ;
using System.Collections.Generic ;

using todoAPI.Data ;
using todoAPI.Models ;

namespace todoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // context variable
        private readonly ApplicationDbContext _context ;

        // Declare class constructor
        public TodoController(
            ApplicationDbContext context 
        )
        {
            _context = context ;
        }


        // POST: api/todo
        // This API is used to create a todo
        [HttpPost]
        public async Task<IActionResult> CreateTodo(
            [FromBody] TodoModel model 
        )
        {
            model.Created = DateTime.Now ;
            model.Modified = DateTime.Now ;

            _context.Todos.Add(model) ;
            await _context.SaveChangesAsync() ;
            return CreatedAtAction(
                nameof(GetTodoDetails),
                new { id = model.TodoId },
                model
            ) ;
        }

        // PUT: api/todo/{id}
        // This API is used to update todo data
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(
            Guid id,
            [FromBody] TodoModel model
        )
        {
            // Get todo
            if ( id != model.TodoId )
            {
                return BadRequest();
            }
            _context.Entry(model).State = EntityState.Modified ;
            try {
                model.Modified = DateTime.Now ;
                await _context.SaveChangesAsync() ;
            }catch(
                DbUpdateConcurrencyException
            ){
                // Check if Todo exists.
                if ( ! _context.Todos.Any( e => e.TodoId == id ) )
                {
                    return NotFound() ;
                }
                throw ;
            }

            return NoContent() ;
        }

        // DELETE: api/todo/{id}
        // This API is used to delete todo data
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(
            Guid id
        )
        {
            var todo = await _context.Todos.FindAsync( id ) ;
            if ( null == todo )
            {
                return NotFound() ;
            }

            _context.Todos.Remove(todo) ;
            await _context.SaveChangesAsync() ;

            return NoContent() ;
        }

        // GET: api/todo
        // This API is used to get all todo data records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetTodos()
        {
            var todos = await _context.Todos.ToListAsync() ;
            return Ok(todos) ;
        }

        // GET: api/todo/{id}
        // This API is used to get todo details
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetTodoDetails(
            Guid id
        )
        {
            var todo = await _context.Todos.FindAsync( id ) ;
            if ( null == todo )
            {
                return NotFound() ;
            }

            return Ok(todo) ;
        }
    }
}
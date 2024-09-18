using Microsoft.AspNetCore.Mvc ;
using Microsoft.EntityFrameworkCore ;
using System.Linq ;
using System.Threading.Tasks ;
using System.Collections.Generic ;

using todoAPI.Data ;

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
            // To be implmented
        }

        // PUT: api/todo/{id}
        // This API is used to update todo data
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(
            Guid id,
            [FromBody] TodoModel model
        )
        {
            // To be implemented
        }

        // DELETE: api/todo/{id}
        // This API is used to delete todo data
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(
            Guid id
        )
        {
            // To be implemented
        }

        // GET: api/todo
        // This API is used to get all todo data records
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetTodos()
        {
            // To be implemented
        }

        // GET: api/todo/{id}
        // This API is used to get todo details
        public async Task<ActionResult<TodoModel>> GetTodo(
            Guid id
        )
        {
            // To be implmeneted
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSimple.Data;
using WebApiSimple.Models;

namespace WebApiSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private IRepository<TodoItem> repo;

        public TodoItemsController(IRepository<TodoItem> r)
        {
            repo = r;
        }

        // GET: api/TodoItems
        [HttpGet]
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return repo.GetAll();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(long id)
        {
            var todoItem = repo.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            repo.Update(todoItem);

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            repo.Add(todoItem);

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTodoItem(long id)
        {
            var todoItem = repo.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            repo.Delete(id);
            return NoContent();
        }

        //private bool TodoItemExists(long id)
        //{
        //    return _context.TodoItems.Any(e => e.Id == id);
        //}
    }
}

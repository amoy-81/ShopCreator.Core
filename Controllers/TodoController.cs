using Microsoft.AspNetCore.Mvc;
using LiaraTodoApp.Models;

namespace LiaraTodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> _items = new();

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            return Ok(_items);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
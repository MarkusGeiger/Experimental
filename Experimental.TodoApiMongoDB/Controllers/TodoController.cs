using System.Collections.Generic;
using Experimental.TodoApiMongoDB.Models;
using Experimental.TodoApiMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Experimental.TodoApiMongoDB.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly TodoService _todoService;

    public TodoController(TodoService bookService)
    {
      _todoService = bookService;
    }

    [HttpGet]
    public ActionResult<List<TodoListItem>> Get() =>
        _todoService.Get();

    [HttpGet("{id:length(24)}", Name = "GetTodo")]
    public ActionResult<TodoListItem> Get(string id)
    {
      var todo = _todoService.Get(id);

      if (todo == null)
      {
        return NotFound();
      }

      return todo;
    }

    [HttpPost]
    public ActionResult<Book> Create(TodoListItem todo)
    {
      _todoService.Create(todo);

      return CreatedAtRoute("GetTodo", new { id = todo.Id.ToString() }, todo);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, TodoListItem todoIn)
    {
      var todo = _todoService.Get(id);

      if (todo == null)
      {
        return NotFound();
      }

      _todoService.Update(id, todoIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var todo = _todoService.Get(id);

      if (todo == null)
      {
        return NotFound();
      }

      _todoService.Remove(todo.Id);

      return NoContent();
    }
  }
}
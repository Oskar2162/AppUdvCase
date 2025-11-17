using Microsoft.AspNetCore.Mvc;
using ServerApp.Model;
using ServerApp.Repositories;

namespace ServerApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    // Statisk så den kun oprettes én gang og deles mellem alle requests
    private static ToDoInMemory _repository = new ToDoInMemory();

    [HttpGet]
    public ActionResult<TodoItem[]> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpPost]
    public ActionResult AddItem([FromBody] TodoItem item)
    {
        _repository.AddItem(item);
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateItem([FromBody] TodoItem item)
    {
        _repository.UpdateItem(item);
        return Ok();
    }
}
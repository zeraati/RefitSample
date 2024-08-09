using Refit;
using Microsoft.AspNetCore.Mvc;

namespace RefitSample.Controllers;
[Route("api/[controller]"), ApiController]
public class ValuesController : ControllerBase
{
    private readonly IJsonPlaceHolder _jsonPlaceHolder;
    public ValuesController(IJsonPlaceHolder jsonPlaceHolder) => _jsonPlaceHolder = jsonPlaceHolder;

    [HttpGet("{UserId}")]
    public async Task<IActionResult> Get(int UserId)
    {
        var response =await _jsonPlaceHolder.GetTodoItem(UserId);
        return Ok(response);
    }
}

public interface IJsonPlaceHolder
{
    [Get("/todos/{UserId}")]
    Task<TodoItem> GetTodoItem(int userId);
}

public class TodoItem
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
}

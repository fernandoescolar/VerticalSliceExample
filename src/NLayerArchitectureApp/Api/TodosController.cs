namespace MvcApp.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
	private readonly ITodoManager _manager;

	public TodosController(ITodoManager store)
		=> _manager = store;

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var todos = await _manager.GetTodosAsync();
		if (!todos.Any())
		{
			return NoContent();
		}

		return Ok(todos);
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetOne(int id)
	{
		var todo = await _manager.GetTodoAsync(id);
		if (todo == null)
		{
			return NotFound();
		}

		return Ok(todo);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Todo todo)
	{
		if (todo == null)
		{
			return BadRequest();
		}

		todo = await _manager.AddTodoAsync(todo.Title);

		return Created($"{Request.GetDisplayUrl()}/{todo.Id}", null);
	}

	[HttpPatch("{id:int}/done")]
	public async Task<IActionResult> Patch(int id)
	{
		var todo = await _manager.GetTodoAsync(id);

		await _manager.MarkAsDoneAsync(todo);

		return Ok(todo);
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		await _manager.DeleteTodoAsync(id);

		return Ok();
	}
}

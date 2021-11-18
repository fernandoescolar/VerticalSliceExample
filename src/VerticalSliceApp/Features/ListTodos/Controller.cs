namespace VerticalSliceApp.Features.ListTodos;

[ApiController]
public class Controller : ControllerBase
{
    private readonly Handler _handler;

    public Controller(Handler handler)
        => _handler = handler;

    [HttpGet("api/todos")]
    public async Task<IActionResult> EnpointAsync()
    {
        var model = await _handler.HandleAsync();
        return Ok(model);
    }
}

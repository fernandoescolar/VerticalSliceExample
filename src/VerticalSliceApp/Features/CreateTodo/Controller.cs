namespace VerticalSliceApp.Features.CreateTodo;

[ApiController]
public class Controller : ControllerBase
{
    private readonly IMediator _mediator;

    public Controller(IMediator mediator)
        => _mediator = mediator;

    [HttpPost("api/todos")]
    public async Task<IActionResult> EnpointAsync([FromBody] Command command)
    {
        var model = await _mediator.Send(command, HttpContext.RequestAborted);
        if (model.IsFailed)
        {
            return Problem(statusCode: 429, detail: string.Join('\n', model.Errors.Select(x => x.Message)));
        }

        return StatusCode(201);
    }
}

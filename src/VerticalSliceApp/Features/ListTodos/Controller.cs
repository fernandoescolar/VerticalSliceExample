namespace VerticalSliceApp.Features.ListTodos;

[ApiController]
public class Controller : ControllerBase
{
    private readonly IMediator _mediator;

    public Controller(IMediator mediator)
        => _mediator = mediator;

    [HttpGet("api/todos")]

    public async Task<IActionResult> EnpointAsync()
    {
        var model = await _mediator.Send(new Query(), HttpContext.RequestAborted);
        if (model.IsFailed)
        {
            return Problem(statusCode: 429, detail: string.Join('\n', model.Errors.Select(x => x.Message)));
        }

        return Ok(model.Value);
    }
}

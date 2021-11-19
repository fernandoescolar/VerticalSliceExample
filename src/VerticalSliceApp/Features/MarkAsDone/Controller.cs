namespace VerticalSliceApp.Features.MarkAsDone;

[ApiController]
public class Controller : ControllerBase
{
    private readonly IMediator _mediator;

    public Controller(IMediator mediator)
        => _mediator = mediator;

    [HttpPatch("{id:int}/done")]
    public async Task<IActionResult> EnpointAsync(int id)
    {
        var command = new Command { Id = id};
        var model = await _mediator.Send(command, HttpContext.RequestAborted);
        if (model.IsFailed)
        {
            return Problem(statusCode: 429, detail: string.Join('\n', model.Errors.Select(x => x.Message)));
        }

        return Ok();
    }
}

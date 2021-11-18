namespace VerticalSliceApp.Features.CreateTodo;

[ApiController]
public class Controller : ControllerBase
{
    private readonly Validator _validator;
    private readonly Handler _handler;

    public Controller(Validator validator, Handler handler)
    {
        _validator = validator;
        _handler = handler;
    }

    [HttpPost("api/todos")]
    public async Task<IActionResult> EnpointAsync([FromBody] Command command)
    {
        if (!_validator.Validate(command))
        {
            return BadRequest(_validator.Error);
        }

        var model = await _handler.HandleAsync(command);
        if (!model.IsSucceded)
        {
            return Problem(statusCode: 429, detail: "Server exhaustion");
        }

        return Ok(model);
    }
}

namespace VerticalSliceApp.Features.ListTodos;

public class Handler : IRequestHandler<Query, Result<Response>>
{
    private readonly Service _service;

    public Handler(Service service)
        => _service = service;

    public async Task<Result<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Result.Ok(await _service.GetAllTodosAsync(cancellationToken));
    }
}

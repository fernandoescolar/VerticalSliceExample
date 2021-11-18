namespace VerticalSliceApp.Features.ListTodos;

public class Handler
{
    private readonly Service _service;

    public Handler(Service service)
        => _service = service;

    public Task<Response> HandleAsync()
        => Task.FromResult(_service.GetAllTodos());
}

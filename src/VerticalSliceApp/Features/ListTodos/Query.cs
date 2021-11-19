namespace VerticalSliceApp.Features.ListTodos;

[Cache(SlidingExpirationInSeconds = 10)]
public class Query : IRequest<Result<Response>>
{
}

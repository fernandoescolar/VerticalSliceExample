namespace VerticalSliceApp.Features.CreateTodo;

public class Command : IRequest<Result>
{
    public string Title { get; set; }
}

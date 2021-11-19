namespace VerticalSliceApp.Features.CreateTodo;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}


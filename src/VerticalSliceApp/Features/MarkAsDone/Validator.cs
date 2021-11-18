namespace VerticalSliceApp.Features.MarkAsDone;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
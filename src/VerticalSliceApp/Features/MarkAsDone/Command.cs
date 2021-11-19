using FluentValidation.Results;

namespace VerticalSliceApp.Features.MarkAsDone;

public class Command : IRequest<Result>
{
    public int Id { get; set; }
}

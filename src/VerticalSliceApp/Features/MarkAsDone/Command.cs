using FluentValidation.Results;

namespace VerticalSliceApp.Features.MarkAsDone;

public class Command : IRequest<Response>
{
    public int Id { get; set; }
}

namespace VerticalSliceApp.Features.MarkAsDone;

public class Handler : IRequestHandler<Command, Response>
{
    private readonly Database _database;

    public Handler(Database database)
    {
        _database = database;
    }

    public Task<Response> Handle(Command command, CancellationToken cancellationToken)
    {
        var todo = _database[command.Id] as Todo;
        _database[command.Id] = todo with { IsDone = true };
        return Task.FromResult(Response.Succeded());
    }
}
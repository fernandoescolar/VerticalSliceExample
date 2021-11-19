namespace VerticalSliceApp.Features.CreateTodo;

public class Handler : IRequestHandler<Command, Result>
{
    private readonly Database _database;

    public Handler(Database database)
        => _database = database;

    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var todo = new Todo(0, command.Title, false);

        _database.Add(todo);
        await _database.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}

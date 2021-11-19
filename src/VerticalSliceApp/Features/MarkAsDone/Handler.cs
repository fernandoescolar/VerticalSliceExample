namespace VerticalSliceApp.Features.MarkAsDone;

public class Handler : IRequestHandler<Command, Result>
{
    private readonly Database _database;

    public Handler(Database database)
    {
        _database = database;
    }

    public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var todo = _database.Todos.AsNoTracking().Single(x => x.Id == command.Id);
        todo = todo with { IsDone = true };
        _database.Todos.Update(todo);
        await _database.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
namespace VerticalSliceApp.Features.CreateTodo;

public class Handler
{
    private readonly Database _database;

    public Handler(Database database)
        => _database = database;

    public Task<Response> HandleAsync(Command command)
    {
        var id = _database.CreateId();
        var todo = new Todo(id, command.Title, false);
        _database[id] = new Todo(id, command.Title, false);

        return Task.FromResult(Response.Succeded());
    }
}

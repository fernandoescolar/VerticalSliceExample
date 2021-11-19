namespace VerticalSliceApp.Features.ListTodos;

public class Service
{
    private readonly Database _database;

    public Service(Database database)
        => _database = database;

    public async Task<Response> GetAllTodosAsync(CancellationToken cancellationToken)
    {
        var response = new Response();
        var todos = await _database.Todos.AsNoTracking().ToListAsync(cancellationToken);
        foreach(var todo in todos)
        {
            response.Add(new ResponseItem { Id = todo.Id, Title = todo.Title, IsDone = todo.IsDone });
        }

        return response;
    }
}

namespace VerticalSliceApp.Features.ListTodos;

public class Service
{
    private readonly Database _database;

    public Service(Database database)
        => _database = database;

    public Response GetAllTodos()
    {
        var response = new Response();
        var todos = _database.Values.Cast<Todo>();
        foreach(var todo in todos)
        {
            response.Add(new ResponseItem { Id = todo.Id, Title = todo.Title, IsDone = todo.IsDone });
        }

        return response;
    }
}

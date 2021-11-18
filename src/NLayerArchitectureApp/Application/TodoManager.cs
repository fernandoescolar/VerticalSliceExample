namespace NLayerArchitectureApp.Application;

public class TodoManager : ITodoManager
{
    private readonly ITodoRepository _repository;

    public TodoManager(ITodoRepository todoRepository)
    {
        _repository = todoRepository;
    }

    public Task<Todo> AddTodoAsync(string title)
    {
        return _repository.InsertAsync(new Todo(0, title, false));
    }

    public Task<Todo> GetTodoAsync(int id)
    {
        return _repository.GetOneAsync(id);
    }

    public Task<IEnumerable<Todo>> GetTodosAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task MarkAsDoneAsync(Todo todo)
    {
        return _repository.UpsertAsync(todo.Id, todo with { IsDone = true });
    }

    public Task DeleteTodoAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}
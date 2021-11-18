namespace NLayerArchitectureApp.Application;

public interface ITodoManager
{
    Task<Todo> AddTodoAsync(string title);
    Task DeleteTodoAsync(int id);
    Task<Todo> GetTodoAsync(int id);
    Task<IEnumerable<Todo>> GetTodosAsync();
    Task MarkAsDoneAsync(Todo todo);
}

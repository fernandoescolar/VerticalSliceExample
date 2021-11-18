namespace NLayerArchitectureApp.Domain.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAllAsync();

    Task<Todo> GetOneAsync(int id);

    Task<Todo> InsertAsync(Todo todo);

    Task<Todo> UpsertAsync(int id, Todo todo);

    Task DeleteAsync(int id);
}

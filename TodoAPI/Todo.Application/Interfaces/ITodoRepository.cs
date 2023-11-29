using Todo.Domain;
namespace Todo.Application.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<TodoItems>> GetTodosAsync();
        Task<TodoItems> GetTodoByIdAsync(int id);
        Task<int> AddTodoAsync(TodoItems todo);
        Task UpdateTodoAsync(TodoItems todo);
        Task DeleteTodoAsync(int id);
    }
}

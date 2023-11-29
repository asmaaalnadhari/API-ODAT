using Todo.Application.Interfaces;
using Todo.Domain;
namespace Todo.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoItems>> GetTodosAsync()
        {
            return await _todoRepository.GetTodosAsync();
        }

        public async Task<TodoItems> GetTodoByIdAsync(int id)
        {
            return await _todoRepository.GetTodoByIdAsync(id);
        }

        public async Task<int> AddTodoAsync(TodoItems todo)
        {
            return await _todoRepository.AddTodoAsync(todo);
        }

        public async Task UpdateTodoAsync(TodoItems todo)
        {
            await _todoRepository.UpdateTodoAsync(todo);
        }

        public async Task DeleteTodoAsync(int id)
        {
            await _todoRepository.DeleteTodoAsync(id);
        }
    }
}

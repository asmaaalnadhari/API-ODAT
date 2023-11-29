using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;
using Todo.Infrastructure.Data;
using Todo.Domain;


namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TodoItems>> GetTodosAsync()
        {
            return await _dbContext.Todos.ToListAsync();
        }

        public async Task<TodoItems> GetTodoByIdAsync(int id)
        {
            return await _dbContext.Todos.FindAsync(id);
        }

        public async Task<int> AddTodoAsync(TodoItems todo)
        {
            _dbContext.Todos.Add(todo);
            await _dbContext.SaveChangesAsync();
            return todo.Id;
        }

        public async Task UpdateTodoAsync(TodoItems todo)
        {
            _dbContext.Entry(todo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            _dbContext.Todos.Remove(todo);
            await _dbContext.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Contracts;
using TaskManager.Domain.TodoTasks;
using TaskManager.Infrastructure.DB;

namespace TaskManager.Infrastructure.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TaskManagerDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public TodoTaskRepository(TaskManagerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(TodoTask entity)
        {
            await _context.TodoTasks.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(TodoTask task)
        {
            _context.TodoTasks.Remove(task);
            await SaveAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetAllAsync()
        {
            return await _context.TodoTasks.ToListAsync();
        }

        public async Task<TodoTask?> GetByIdAsync(string id)
        {
            return await _context.TodoTasks.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TodoTask entity)
        {
            entity.UpdateModifiedDate();
            _context.Entry(entity).State = EntityState.Modified;
            _context.TodoTasks.Update(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

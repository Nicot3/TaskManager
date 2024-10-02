using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Contracts;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Infrastructure.DB.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TaskManagerDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public TodoTaskRepository(TaskManagerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(TodoTask entity, CancellationToken cancellationToken = default)
        {
            await _context.TodoTasks.AddAsync(entity, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public async Task DeleteAsync(TodoTask task, CancellationToken cancellationToken = default)
        {
            _context.TodoTasks.Remove(task);
            await SaveAsync(cancellationToken);
        }

        public async Task<IEnumerable<TodoTask>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.TodoTasks.ToListAsync(cancellationToken);
        }

        public async Task<TodoTask?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.TodoTasks.Where(t => t.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateAsync(TodoTask entity, CancellationToken cancellationToken = default)
        {
            entity.UpdateModifiedDate();
            _context.Entry(entity).State = EntityState.Modified;
            _context.TodoTasks.Update(entity);
            await SaveAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

using TaskManager.Domain.Common.Contracts;

namespace TaskManager.Domain.TodoTasks
{
    public interface ITodoTaskRepository : IRepository<TodoTask, string>
    {
        Task<IEnumerable<TodoTask>> GetAllIncompleteAsync(CancellationToken cancellationToken = default);
    }
}

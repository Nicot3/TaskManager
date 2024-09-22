using TaskManager.Domain.Common.Contracts;

namespace TaskManager.Domain.Tasks.Contracts
{
    public interface ITodoTaskRepository : IRepository<TodoTask>
    {
    }
}

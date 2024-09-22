using TaskManager.Domain.Common;
using TaskManager.Domain.Tasks;

namespace TaskManager.Domain.Tasks.Contracts
{
    public interface ITask
    {
        string Name { get; set; }
        string? Description { get; set; }
        TodoTaskType TaskType { get; set; }
    }
}

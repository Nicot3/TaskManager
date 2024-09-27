
namespace TaskManager.Domain.TodoTasks.Contracts
{
    public interface ITodoTask
    {
        string Name { get; }
        string? Description { get; }
        bool IsCompleted { get; }

        DateTime CreatedDate { get; }
        DateTime? ModifiedDate { get; }

        TodoTaskType TaskType { get; }
    }
}

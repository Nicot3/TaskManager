
namespace TaskManager.Domain.TodoTasks.Contracts
{
    public interface ITodoTask
    {
        string Name { get; set; }
        string? Description { get; set; }
        bool IsCompleted { get; set; }

        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }

        TodoTaskType TaskType { get; set; }
    }
}

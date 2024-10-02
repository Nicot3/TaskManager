using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetTodoTaskById
{
    public class GetTodoTaskByIdQueryResult
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public IEnumerable<GetTodoTaskByIdQueryResultTag> Tags { get; init; } = new List<GetTodoTaskByIdQueryResultTag>();

        public bool IsCompleted { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? ModifiedDate { get; init; }

        public TodoTaskType TaskType { get; init; }

        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }

    public class GetTodoTaskByIdQueryResultTag
    {
        public required string Name { get; init; }
    }
}

using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetTodoTasks
{
    public class GetTodoTasksQueryResult
    {
        public required IEnumerable<GetTodoTasksQueryResultTask> TodoTasks { get; init; }
    }

    public class GetTodoTasksQueryResultTask
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public IEnumerable<GetTodoTasksQueryResultTag> Tags { get; init; } = new List<GetTodoTasksQueryResultTag>();

        public bool IsCompleted { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? ModifiedDate { get; init; }

        public TodoTaskType TaskType { get; init; }

        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }

    public class GetTodoTasksQueryResultTag
    {
        public required string Name { get; init; }
    }
}

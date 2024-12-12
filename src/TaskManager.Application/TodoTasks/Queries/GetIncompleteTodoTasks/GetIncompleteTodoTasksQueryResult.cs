using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetIncompleteTodoTasks
{
    public class GetIncompleteTodoTasksQueryResult
    {
        public required IEnumerable<GetIncompleteTodoTasksQueryResultTask> TodoTasks { get; init; }
    }

    public class GetIncompleteTodoTasksQueryResultTask
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public IEnumerable<GetIncompleteTodoTasksQueryResultTag> Tags { get; init; } = new List<GetIncompleteTodoTasksQueryResultTag>();

        public bool IsCompleted { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? ModifiedDate { get; init; }

        public TodoTaskType TaskType { get; init; }

        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }

    public class GetIncompleteTodoTasksQueryResultTag
    {
        public required string Name { get; init; }
    }
}

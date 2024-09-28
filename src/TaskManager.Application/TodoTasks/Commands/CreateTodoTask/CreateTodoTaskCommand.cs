using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Commands.CreateTodoTask
{
    public class CreateTodoTaskCommand : ICommand
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<CreateTodoTaskCommandTag>? Tags { get; set; }

        public TodoTaskType TaskType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class CreateTodoTaskCommandTag
    {
        public required string Name { get; set; }
    }
}

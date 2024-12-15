using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Commands.UpdateTodoTask
{
    public class UpdateTodoTaskCommand : ICommand
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }

        public TodoTaskType? TaskType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

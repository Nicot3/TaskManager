
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Domain.Tasks;

namespace TaskManager.Application.Task.Commands.CreateTask
{
    public class CreateTodoTaskCommand : ICommand
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public TodoTaskType TaskType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

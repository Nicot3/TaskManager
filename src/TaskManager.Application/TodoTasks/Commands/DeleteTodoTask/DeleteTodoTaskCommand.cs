using TaskManager.Application.Common.Contracts.Commands;

namespace TaskManager.Application.TodoTasks.Commands.DeleteTodoTask
{
    public class DeleteTodoTaskCommand : ICommand
    {
        public required string TodoTaskId { get; init; }
    }
}

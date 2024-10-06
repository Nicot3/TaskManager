using TaskManager.Application.Common.Contracts.Commands;

namespace TaskManager.Application.TodoTasks.Commands.AddTag
{
    public class AddTagCommand : ICommand
    {
        public required string TodoTaskId { get; init; }
        public required string Name { get; init; }
    }
}

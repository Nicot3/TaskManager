using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Commands.DeleteTodoTask
{
    public class DeleteTodoTaskCommandHandler : ICommandHandler<DeleteTodoTaskCommand>
    {
        private readonly ITodoTaskRepository repository;

        public DeleteTodoTaskCommandHandler(ITodoTaskRepository repository)
        {
            this.repository = repository;
        }
        public async Task HandleAsync(DeleteTodoTaskCommand command, CancellationToken cancellationToken = default)
        {
            var task = await repository.GetByIdAsync(command.TodoTaskId, cancellationToken);

            if (task == null)
            {
                throw new ArgumentException($"Task {command.TodoTaskId} doesn't exists");
            }

            await repository.DeleteAsync(task, cancellationToken);
        }
    }
}

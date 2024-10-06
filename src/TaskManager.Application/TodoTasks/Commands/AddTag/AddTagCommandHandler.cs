using TaskManager.Application.Common.Contracts;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Application.Common.Exceptions;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Commands.AddTag
{
    public class AddTagCommandHandler : ICommandHandler<AddTagCommand, bool>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddTagCommandHandler(ITodoTaskRepository todoTaskRepository, IUnitOfWork unitOfWork)
        {
            _todoTaskRepository = todoTaskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> HandleAsync(AddTagCommand command, CancellationToken cancellationToken = default)
        {
            var task = await _todoTaskRepository.GetByIdAsync(command.TodoTaskId, cancellationToken);

            if (task == null)
            {
                throw new EntityNotFoundException($"TodoTask with id {command.TodoTaskId} doesn't exists.");
            }

            task.AddTag(command.Name);

            await _todoTaskRepository.UpdateAsync(task, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

using TaskManager.Application.Common.Contracts;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Commands.CreateTodoTask
{
    public class CreateTodoTaskCommandHandler : ICommandHandler<CreateTodoTaskCommand, string>
    {
        private readonly ITodoTaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoTaskCommandHandler(ITodoTaskRepository taskRepository,
                                            IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> HandleAsync(CreateTodoTaskCommand command, CancellationToken cancellationToken = default)
        {
            var task = new TodoTask(command.Name, command.Description, command.TaskType, false, command.StartDate, command.EndDate);

            await _taskRepository.CreateAsync(task, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}

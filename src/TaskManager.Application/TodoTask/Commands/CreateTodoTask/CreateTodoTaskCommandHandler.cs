using TaskManager.Application.Common.Contracts;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Domain.Tasks;
using TaskManager.Domain.Tasks.Contracts;

namespace TaskManager.Application.Task.Commands.CreateTask
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

        public async Task<string> HandleAsync(CreateTodoTaskCommand command)
        {
            var task = new TodoTask() 
            {
                CreatedAt = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                Name = command.Name,
                Description = command.Description,
                TaskType = command.TaskType,
                StartDate = command.StartDate,
                EndDate = command.EndDate
            };

            await _taskRepository.CreateAsync(task);

            await _unitOfWork.CommitAsync();

            return task.Id;
        }
    }
}

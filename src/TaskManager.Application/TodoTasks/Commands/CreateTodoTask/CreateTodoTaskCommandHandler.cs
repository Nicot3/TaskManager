using AutoMapper;
using TaskManager.Application.Common.Contracts;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Commands.CreateTodoTask
{
    public class CreateTodoTaskCommandHandler : ICommandHandler<CreateTodoTaskCommand, string>
    {
        private readonly ITodoTaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTodoTaskCommandHandler(ITodoTaskRepository taskRepository,
                                            IUnitOfWork unitOfWork,
                                            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> HandleAsync(CreateTodoTaskCommand command, CancellationToken cancellationToken = default)
        {
            //var task = new TodoTask(command.Name, command.Description, command.TaskType, false, command.StartDate, command.EndDate);

            var task = _mapper.Map<TodoTask>(command);

            await _taskRepository.CreateAsync(task, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}

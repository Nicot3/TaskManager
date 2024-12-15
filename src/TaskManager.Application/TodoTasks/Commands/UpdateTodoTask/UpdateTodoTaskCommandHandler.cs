using AutoMapper;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Commands.UpdateTodoTask
{
    public class UpdateTodoTaskCommandHandler : ICommandHandler<UpdateTodoTaskCommand, bool>
    {
        private readonly ITodoTaskRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTodoTaskCommandHandler(ITodoTaskRepository repository,
                                            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> HandleAsync(UpdateTodoTaskCommand command,
                                      CancellationToken cancellationToken = default)
        {
            var task = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (task == null)
            {
                throw new ArgumentException($"Task with id {command.Id} doesn't exists");
            }

            task.UpdateTask(command.Name,
                            command.Description,
                            command.IsCompleted,
                            command.TaskType,
                            command.StartDate,
                            command.EndDate);

            await _repository.UpdateAsync(task, cancellationToken);

            return true;
        }
    }
}

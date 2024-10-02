using AutoMapper;
using TaskManager.Application.Common.Contracts.Queries;
using TaskManager.Application.Common.Exceptions;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetTodoTaskById
{
    public class GetTodoTaskByIdQueryHandler : IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;
        private readonly IMapper _mapper;

        public GetTodoTaskByIdQueryHandler(ITodoTaskRepository todoTaskRepository,
                                           IMapper mapper)
        {
            _todoTaskRepository = todoTaskRepository;
            _mapper = mapper;
        }

        public async Task<GetTodoTaskByIdQueryResult> ExecuteAsync(GetTodoTaskByIdQuery query, CancellationToken cancellationToken = default)
        {
            var todoTask = await _todoTaskRepository.GetByIdAsync(query.Id, cancellationToken);

            if (todoTask == null)
            {
                throw new EntityNotFoundException($"Task with id {query.Id} doesn't exists");
            }

            var queryResult = _mapper.Map<GetTodoTaskByIdQueryResult>(todoTask);

            return queryResult;
        }
    }
}

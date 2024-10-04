using AutoMapper;
using TaskManager.Application.Common.Contracts.Queries;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetTodoTasks
{
    public class GetTodoTasksQueryHandler : IQueryHandler<GetTodoTasksQuery, GetTodoTasksQueryResult>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;
        private readonly IMapper _mapper;

        public GetTodoTasksQueryHandler(ITodoTaskRepository todoTaskRepository, IMapper mapper)
        {
            _todoTaskRepository = todoTaskRepository;
            _mapper = mapper;
        }

        public async Task<GetTodoTasksQueryResult> ExecuteAsync(GetTodoTasksQuery query, CancellationToken cancellationToken = default)
        {
            var tasks = await _todoTaskRepository.GetAllAsync(cancellationToken);

            var queryResult = _mapper.Map<GetTodoTasksQueryResult>(tasks);

            return queryResult;
        }
    }
}

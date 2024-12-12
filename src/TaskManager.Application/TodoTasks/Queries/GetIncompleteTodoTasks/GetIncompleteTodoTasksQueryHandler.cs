using AutoMapper;
using TaskManager.Application.Common.Contracts.Queries;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetIncompleteTodoTasks
{
    public class GetIncompleteTodoTasksQueryHandler : IQueryHandler<GetIncompleteTodoTasksQuery, GetIncompleteTodoTasksQueryResult>
    {
        private readonly ITodoTaskRepository _repository;
        private readonly IMapper _mapper;

        public GetIncompleteTodoTasksQueryHandler(ITodoTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetIncompleteTodoTasksQueryResult> ExecuteAsync(GetIncompleteTodoTasksQuery query, CancellationToken cancellationToken = default)
        {
            var incompleteTodoTasks = await _repository.GetAllIncompleteAsync(cancellationToken);

            var queryResult = _mapper.Map<GetIncompleteTodoTasksQueryResult>(incompleteTodoTasks);

            return queryResult;
        }
    }
}

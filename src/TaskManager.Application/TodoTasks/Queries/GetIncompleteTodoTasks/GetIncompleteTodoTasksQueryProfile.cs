using AutoMapper;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetIncompleteTodoTasks
{
    public class GetIncompleteTodoTasksQueryProfile : Profile
    {
        public GetIncompleteTodoTasksQueryProfile()
        {
            CreateMap<IEnumerable<TodoTask>, GetIncompleteTodoTasksQueryResult>()
                .ForMember(dst => dst.TodoTasks, opts => opts.MapFrom(src => src));
            CreateMap<TodoTask, GetIncompleteTodoTasksQueryResultTask>();
            CreateMap<Tag, GetIncompleteTodoTasksQueryResultTag>();
        }
    }
}

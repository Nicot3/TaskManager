using AutoMapper;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetTodoTasks
{
    public class GetTodoTasksQueryProfile : Profile
    {
        public GetTodoTasksQueryProfile()
        {
            CreateMap<IEnumerable<TodoTask>, GetTodoTasksQueryResult>()
                .ForMember(dst => dst.TodoTasks, opts => opts.MapFrom(src => src));
            CreateMap<TodoTask, GetTodoTasksQueryResultTask>();
            CreateMap<Tag, GetTodoTasksQueryResultTag>();
        }
    }
}

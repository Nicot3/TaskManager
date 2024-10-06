using AutoMapper;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetTodoTaskById
{
    public class GetTodoTaskByIdQueryProfile : Profile
    {
        public GetTodoTaskByIdQueryProfile()
        {
            CreateMap<TodoTask, GetTodoTaskByIdQueryResult>();
            CreateMap<Tag, GetTodoTaskByIdQueryResultTag>();
        }
    }
}

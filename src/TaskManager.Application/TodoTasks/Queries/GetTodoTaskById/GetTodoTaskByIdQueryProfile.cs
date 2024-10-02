using AutoMapper;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Queries.GetTodoTaskById
{
    public class GetTodoTaskByIdQueryProfile : Profile
    {
        protected GetTodoTaskByIdQueryProfile()
        {
            CreateMap<TodoTask, GetTodoTaskByIdQueryResult>();
        }
    }
}

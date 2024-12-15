using AutoMapper;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Application.TodoTasks.Commands.CreateTodoTask
{
    public class CreateTodoTaskProfile : Profile
    {
        public CreateTodoTaskProfile()
        {
            CreateMap<CreateTodoTaskCommand, TodoTask>();
        }
    }
}

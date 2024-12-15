using Microsoft.Extensions.Configuration;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Application.Common.Contracts.Queries;
using TaskManager.Application.TodoTasks.Commands.AddTag;
using TaskManager.Application.TodoTasks.Commands.CreateTodoTask;
using TaskManager.Application.TodoTasks.Commands.DeleteTodoTask;
using TaskManager.Application.TodoTasks.Commands.UpdateTodoTask;
using TaskManager.Application.TodoTasks.Queries.GetIncompleteTodoTasks;
using TaskManager.Application.TodoTasks.Queries.GetTodoTaskById;
using TaskManager.Application.TodoTasks.Queries.GetTodoTasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult>, GetTodoTaskByIdQueryHandler>();
            services.AddScoped<IQueryHandler<GetTodoTasksQuery, GetTodoTasksQueryResult>, GetTodoTasksQueryHandler>();
            services.AddScoped<IQueryHandler<GetIncompleteTodoTasksQuery, GetIncompleteTodoTasksQueryResult>, GetIncompleteTodoTasksQueryHandler>();

            services.AddScoped<ICommandHandler<CreateTodoTaskCommand, string>, CreateTodoTaskCommandHandler>();
            services.AddScoped<ICommandHandler<AddTagCommand, bool>, AddTagCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteTodoTaskCommand>, DeleteTodoTaskCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateTodoTaskCommand, bool>, UpdateTodoTaskCommandHandler>();

            services.AddAutoMapper(c =>
            {
                c.AddProfile(typeof(GetTodoTaskByIdQueryProfile));
                c.AddProfile(typeof(GetTodoTasksQueryProfile));
                c.AddProfile(typeof(GetIncompleteTodoTasksQueryProfile));
                c.AddProfile(typeof(CreateTodoTaskProfile));
            });

            return services;
        }
    }
}

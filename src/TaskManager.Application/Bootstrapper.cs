using Microsoft.Extensions.Configuration;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Application.Common.Contracts.Queries;
using TaskManager.Application.TodoTasks.Commands.CreateTodoTask;
using TaskManager.Application.TodoTasks.Queries.GetTodoTaskById;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult>, GetTodoTaskByIdQueryHandler>();
            services.AddScoped<ICommandHandler<CreateTodoTaskCommand, string>, CreateTodoTaskCommandHandler>();

            services.AddAutoMapper(c =>
            {
                c.AddProfile(typeof(GetTodoTaskByIdQueryProfile));
            });

            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManager.Application.Common.Contracts;
using TaskManager.Domain.TodoTasks;
using TaskManager.Infrastructure.DB;
using TaskManager.Infrastructure.DB.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<TaskManagerDbContext>(c => {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();

            services.AddScoped<IUnitOfWork, TaskManagerDbContext>();

            return services;
        }
    }
}

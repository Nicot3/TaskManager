using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Common.Contracts;

namespace TaskManager.Infrastructure.DB
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<TaskManagerDbContext>(c => {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped<IUnitOfWork, TaskManagerDbContext>();

            return services;
        }
    }
}

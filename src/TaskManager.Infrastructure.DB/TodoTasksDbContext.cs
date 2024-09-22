using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskManager.Domain.Tasks;

namespace TaskManager.Infrastructure.DB
{
    public class TodoTasksDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<TodoTask> TodoTasks {  get; set; }

        public TodoTasksDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }
    }
}
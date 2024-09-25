using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Infrastructure.DB
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=taskmanager_migrations;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Contracts;
using TaskManager.Domain.TodoTasks;
using TaskManager.Infrastructure.DB.EntityConfigurations;

namespace TaskManager.Infrastructure.DB
{
    public class TaskManagerDbContext : DbContext, IUnitOfWork
    {
        public TaskManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoTaskEntityTypeConfiguration());
        }
    }
}

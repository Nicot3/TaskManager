using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Contracts;
using TaskManager.Domain.TodoTasks;
using TaskManager.Infrastructure.DB.EntityConfigurations;

namespace TaskManager.Infrastructure.DB
{
    public class TaskManagerDbContext : DbContext, IUnitOfWork
    {
        
        public DbSet<TodoTask> TodoTasks { get; set; }

        public TaskManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public TaskManagerDbContext() : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoTaskEntityTypeConfiguration());
        }
    }
}

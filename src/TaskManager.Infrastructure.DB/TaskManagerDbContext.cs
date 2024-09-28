using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Contracts;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Infrastructure.DB
{
    public class TaskManagerDbContext : DbContext, IUnitOfWork
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}

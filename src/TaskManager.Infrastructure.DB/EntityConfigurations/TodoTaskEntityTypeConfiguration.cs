using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Infrastructure.DB.EntityConfigurations
{
    public class TodoTaskEntityTypeConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.HasMany(b => b.Tags)
                .WithMany();
        }
    }
}

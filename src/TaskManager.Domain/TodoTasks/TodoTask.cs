using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Common;
using TaskManager.Domain.Common.Contracts;
using TaskManager.Domain.TodoTasks.Contracts;

namespace TaskManager.Domain.TodoTasks
{
    public class TodoTask : EntityBase, IAggregateRoot, ITodoTask
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        [Required]
        public TodoTaskType TaskType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

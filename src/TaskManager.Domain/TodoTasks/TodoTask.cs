using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Common;
using TaskManager.Domain.Tasks.Contracts;

namespace TaskManager.Domain.Tasks
{
    public class TodoTask : CreationEntityBase<string>, ITask
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public TodoTaskType TaskType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Common;
using TaskManager.Domain.Common.Contracts;
using TaskManager.Domain.TodoTasks.Contracts;

namespace TaskManager.Domain.TodoTasks
{
    public class TodoTask : EntityBase, IAggregateRoot, ITodoTask
    {
        private readonly List<Tag> _tags;

        [Required]
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public IEnumerable<Tag> Tags => _tags;

        public bool IsCompleted { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? ModifiedDate { get; private set; }

        [Required]
        public TodoTaskType TaskType { get; private set; }

        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public TodoTask(string name, string? description, TodoTaskType taskType, bool isCompleted = false, DateTime? startDate = null, DateTime? endDate = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
            Description = description;
            IsCompleted = isCompleted;
            TaskType = taskType;
            StartDate = startDate;
            EndDate = endDate;

            _tags = new List<Tag>();
        }

        public void AddTag(string name)
        {
            var tag = _tags.FirstOrDefault(t => t.Name == name);

            if (tag != null)
            {
                throw new ArgumentException($"Tag with name {name} already exists");
            }

            _tags.Add(new Tag(name));
        }

        public void RemoveTag(string name) {

            var tag = _tags.FirstOrDefault(t => t.Name == name);

            if (tag == null)
            {
                throw new ArgumentException($"Tag with name {name} doesn't exists in the {Id} task tags");
            }

            _tags.Remove(tag);
        }
    }
}

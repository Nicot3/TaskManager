
using TaskManager.Domain.Common;

namespace TaskManager.Domain.TodoTasks
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }

        public Tag(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }
    }
}

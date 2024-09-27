
using TaskManager.Domain.Common.Contracts;

namespace TaskManager.Domain.TodoTasks
{
    public class Tag : IValueObject
    {
        public string Name { get; set; }

        public Tag(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }
    }
}

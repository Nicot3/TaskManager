using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Common
{
    public abstract class EntityBase<T> where T : class
    {
        [Key]
        public required T Id { get; set; }
    }
}

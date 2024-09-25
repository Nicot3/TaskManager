using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}

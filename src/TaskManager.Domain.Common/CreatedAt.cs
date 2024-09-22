namespace TaskManager.Domain.Common
{
    public abstract class CreationEntityBase<T> : EntityBase<T> where T : class
    {
        public required DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}

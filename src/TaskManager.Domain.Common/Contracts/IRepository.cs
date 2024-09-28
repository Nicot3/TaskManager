using TaskManager.Application.Common.Contracts;

namespace TaskManager.Domain.Common.Contracts
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : IAggregateRoot
        where TKey : class
    {
        IUnitOfWork UnitOfWork { get; }

        Task CreateAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity id);
    }
}

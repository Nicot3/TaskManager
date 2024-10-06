using TaskManager.Application.Common.Contracts;

namespace TaskManager.Domain.Common.Contracts
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : IAggregateRoot
        where TKey : class
    {
        IUnitOfWork UnitOfWork { get; }

        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity id, CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetQueryable();
    }
}

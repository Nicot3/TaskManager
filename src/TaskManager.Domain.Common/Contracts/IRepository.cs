namespace TaskManager.Domain.Common.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(TEntity id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity id);
    }
}

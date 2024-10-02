namespace TaskManager.Application.Common.Contracts.Queries
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : class
    {
        Task<TResult> ExecuteAsync(TQuery query, CancellationToken cancellationToken = default);
    }
}

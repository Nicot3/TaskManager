namespace TaskManager.Application.Common.Contracts
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}

using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Aplication.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IStreamerRepository StreamerRepository { get; }
        IVideoRepository VideoRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
    }
}

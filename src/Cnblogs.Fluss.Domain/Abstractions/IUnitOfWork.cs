using System.Threading;
using System.Threading.Tasks;

namespace Cnblogs.Fluss.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
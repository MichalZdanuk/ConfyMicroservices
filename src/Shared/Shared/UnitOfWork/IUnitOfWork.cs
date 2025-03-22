using System.Data;

namespace Shared.UnitOfWork;
public interface IUnitOfWork
{
	Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	Task CommitAsync(CancellationToken cancellationToken = default);
	Task RollbackAsync(CancellationToken cancellationToken = default);
}

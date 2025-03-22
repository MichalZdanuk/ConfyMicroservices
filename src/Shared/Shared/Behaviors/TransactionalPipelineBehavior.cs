using MediatR;
using Microsoft.Extensions.Logging;
using Shared.CQRS;
using Shared.UnitOfWork;

namespace Shared.Behaviors;
public class TransactionalPipelineBehavior<TRequest, TResponse>(
	IUnitOfWork unitOfWork,
	ILogger<TransactionalPipelineBehavior<TRequest, TResponse>> logger)
		: IPipelineBehavior<TRequest, TResponse>
	where TRequest : ICommand<TResponse>
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		logger.LogInformation("Beginning transaction for {RequestName}", typeof(TRequest).Name);

		await unitOfWork.BeginTransactionAsync(cancellationToken);

		try
		{
			TResponse response = await next();

			await unitOfWork.CommitAsync(cancellationToken);
			logger.LogInformation("Commited transaction for {RequestName}", typeof(TRequest).Name);

			return response;
		}
		catch (Exception ex)
		{
			await unitOfWork.RollbackAsync(cancellationToken);
			logger.LogError(ex, "Transaction rolled back for {RequestName}", typeof(TRequest).Name);
			throw;
		}
	}
}

using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Events;
using Shared.UnitOfWork;
using System.Text.Json;

namespace Shared.Messaging.Consumers;
public abstract class TransactionalConsumer<TMessage> : IConsumer<TMessage>
	where TMessage : IntegrationEvent
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ILogger<TransactionalConsumer<TMessage>> _logger;

	protected TransactionalConsumer(IUnitOfWork unitOfWork,
		ILogger<TransactionalConsumer<TMessage>> logger)
	{
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task Consume(ConsumeContext<TMessage> context)
	{
		_logger.LogInformation("Starting transaction for {MessageType}", typeof(TMessage).Name);

		var eventData = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { WriteIndented = true });

		_logger.LogInformation("Handling Integration Event: {integrationEvent}\n EventData: {eventData}",
			context.Message.GetType().Name,
			eventData);

		try
		{
			await HandleMessage(context);

			await _unitOfWork.SaveChangesAsync(context.CancellationToken);
			_logger.LogInformation("Transaction committed for {MessageType}", typeof(TMessage).Name);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Transaction rolled back for {MessageType}", typeof(TMessage).Name);
			await _unitOfWork.RollbackAsync(context.CancellationToken);
			throw;
		}
	}

	protected abstract Task HandleMessage(ConsumeContext<TMessage> context);
}

using ConferenceManagement.Domain.Entities;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Events;
using System.Text.Json;

namespace ConferenceManagement.Application.EventHandlers.Integration;
public class PrelegentCreatedEventHandler(IPrelegentRepository prelegentRepository,
	//IDbContext dbContext,
	ILogger<PrelegentCreatedEventHandler> logger)
	: IConsumer<PrelegentCreatedEvent>
{
	public async Task Consume(ConsumeContext<PrelegentCreatedEvent> context)
	{
		var eventData = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { WriteIndented = true });

		logger.LogInformation("Handling Integration Event: {integrationEvent}\n EventData: {eventData}",
			context.Message.GetType().Name,
			eventData);


		//var prelegent = PreparePrelegentFromEvent(context.Message);

		//await prelegentRepository.AddPrelegentAsync(prelegent);

		//await dbContext.SaveChangesAsync();
	}

	private Prelegent PreparePrelegentFromEvent(PrelegentCreatedEvent prelegentCreatedEvent)
	{
		var user = Prelegent.Create(prelegentCreatedEvent.UserId,
			"name",
			"bio");// TO DO: RETRIEVE FROM AUTHENTICATION SERVICE 

		return user;
	}
}

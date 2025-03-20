using ConferenceManagement.Domain.Data;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.ValueObjects;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Events;
using System.Text.Json;

namespace ConferenceManagement.Application.EventHandlers.Integration;
public class UserRegisteredEventHandler(IUserRepository userRepository,
	IDbContext dbContext,
	ILogger<UserRegisteredEventHandler> logger)
	: IConsumer<UserRegisteredEvent>
{
	public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
	{
		var eventData = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { WriteIndented = true });

		logger.LogInformation("Handling Integration Event: {integrationEvent}\n EventData: {eventData}",
			context.Message.GetType().Name,
			eventData);

		var user = PrepareUserFromEvent(context.Message);

		await userRepository.AddUser(user);

		await dbContext.SaveChangesAsync();
	}

	private User PrepareUserFromEvent(UserRegisteredEvent userRegisteredEvent)
	{
		var user = User.Create(userRegisteredEvent.UserId,
			FullName.Of(userRegisteredEvent.FirstName, userRegisteredEvent.LastName),
			userRegisteredEvent.Email,
			userRegisteredEvent.UserRole);

		return user;
	}
}

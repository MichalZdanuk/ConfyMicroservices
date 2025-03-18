using ConferenceManagement.Application.Data;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Repositories;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Events;

namespace ConferenceManagement.Application.ExternalEvents.EventHandlers;
public class UserRegisteredEventHandler(IUserRepository userRepository,
	IApplicationDbContext dbContext,
	ILogger<UserRegisteredEventHandler> logger)
	: IConsumer<UserRegisteredEvent>
{
	public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
	{
		logger.LogInformation("Integration Event handled: {integrationEvent}", context.Message.GetType().Name);

		var user = PrepareUserFromEvent(context.Message);

		await userRepository.AddUser(user);

		await dbContext.SaveChangesAsync();
	}

	private User PrepareUserFromEvent(UserRegisteredEvent userRegisteredEvent)
	{
		var user = User.Create(userRegisteredEvent.UserId,
			userRegisteredEvent.Email,
			userRegisteredEvent.UserRole);

		return user;
	}
}

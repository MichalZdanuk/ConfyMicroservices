using Registration.Domain.Exceptions;
using Registration.Domain.Repositories;
using Shared.Context;

namespace Registration.Application.Services;
public class RegistrationService(IContext context,
	IConferenceRepository conferenceRepository,
	IRegistrationRepository registrationRepository)
	: IRegistrationService
{

	public async Task<Guid> RegisterUserForConferenceAsync(Guid conferenceId)
	{
		var userId = context.UserId;

		var conference = await conferenceRepository.GetByIdAsync(conferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(conferenceId);
		}

		var registration = await registrationRepository.GetByUserIdAndConferenceId(userId, conferenceId);

		if (registration is null)
		{
			var newRegistration = Domain.Entities.Registration.Create(userId, conferenceId, conference);
			await registrationRepository.AddAsync(newRegistration);

			return newRegistration.Id;
		}
		else
		{
			registration.ReRegister();
			await registrationRepository.UpdateAsync(registration);

			return registration.Id;
		}
	}

	public async Task CancelRegistrationAsync(Guid registrationId)
	{
		var userId = context.UserId;

		var registration = await registrationRepository.GetByIdAsync(registrationId);

		if (registration is null)
		{
			throw new RegistrationNotFoundException(registrationId);
		}

		if (registration.UserId != userId)
		{
			throw new AccessForRegistrationForbiddenException(registrationId);
		}

		registration.Cancel();

		await registrationRepository.UpdateAsync(registration);
	}
}

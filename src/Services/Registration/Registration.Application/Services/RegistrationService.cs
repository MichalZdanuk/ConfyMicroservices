using Registration.Domain.Exceptions;
using Registration.Domain.Repositories;

namespace Registration.Application.Services;
public class RegistrationService(IConferenceRepository conferenceRepository,
	IRegistrationRepository registrationRepository)
	: IRegistrationService
{

	public async Task RegisterUserForConference(Guid userId, Guid conferenceId)
	{
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
		}
		else
		{
			registration.ReRegister();
			await registrationRepository.UpdateAsync(registration);
		}
	}

	public Task CancelRegistrationForConference(Guid userId, Guid conferenceId)
	{
		throw new NotImplementedException();
	}
}

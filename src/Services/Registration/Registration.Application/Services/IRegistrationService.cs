namespace Registration.Application.Services;
public interface IRegistrationService
{
	public Task RegisterUserForConferenceAsync(Guid userId, Guid conferenceId);
	public Task CancelRegistrationAsync(Guid registrationId);
}

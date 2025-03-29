namespace Registration.Application.Services;
public interface IRegistrationService
{
	public Task<Guid> RegisterUserForConferenceAsync(Guid conferenceId);
	public Task CancelRegistrationAsync(Guid registrationId);
}

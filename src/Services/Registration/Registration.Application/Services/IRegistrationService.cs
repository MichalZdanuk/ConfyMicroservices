namespace Registration.Application.Services;
public interface IRegistrationService
{
	public Task RegisterUserForConference(Guid userId, Guid conferenceId);
	public Task CancelRegistrationForConference(Guid userId, Guid conferenceId);
}

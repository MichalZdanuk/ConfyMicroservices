using Shared.Exceptions;

namespace ConferenceManagement.Domain.Exceptions;
public class ConferenceNotFoundException : NotFoundException
{
	public ConferenceNotFoundException(Guid conferenceId) : base($"Conference with id: {conferenceId} was not found")
	{
	}
}

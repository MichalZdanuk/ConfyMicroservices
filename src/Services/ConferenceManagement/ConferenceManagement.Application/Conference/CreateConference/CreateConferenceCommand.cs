using MediatR;

namespace ConferenceManagement.Application.Conference.CreateConference;
public record CreateConferenceCommand(string Name, CreateConferenceDetailsDto ConferenceDetails, CreateAddressDto Address): IRequest
{
	public Guid Id { get; } = Guid.NewGuid();
}

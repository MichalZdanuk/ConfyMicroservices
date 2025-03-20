using MediatR;

namespace ConferenceManagement.Application.Conference.GetConference;
public record GetConferenceQuery(Guid ConferenceId) : IRequest<GetConferenceDto>;

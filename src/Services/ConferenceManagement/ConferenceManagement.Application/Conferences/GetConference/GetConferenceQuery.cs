namespace ConferenceManagement.Application.Conference.GetConference;
public record GetConferenceQuery(Guid ConferenceId) : IQuery<GetConferenceDto>;

namespace ConferenceManagement.Application.Conferences.GetConference;
public record GetConferenceQuery(Guid ConferenceId) : IQuery<GetConferenceDto>;

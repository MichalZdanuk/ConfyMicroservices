namespace ConferenceManagement.Application.Conference.CreateConference;
public record CreateConferenceDetailsDto(DateTime StartDate, DateTime EndDate, string Description, bool IsOnline);

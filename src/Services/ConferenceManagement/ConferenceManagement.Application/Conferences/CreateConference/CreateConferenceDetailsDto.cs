namespace ConferenceManagement.Application.Conferences.CreateConference;
public record CreateConferenceDetailsDto(DateTime StartDate, DateTime EndDate, string Description, bool IsOnline);

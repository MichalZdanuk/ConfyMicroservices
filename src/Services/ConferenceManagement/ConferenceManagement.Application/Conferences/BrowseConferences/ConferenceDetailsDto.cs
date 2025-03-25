namespace ConferenceManagement.Application.Conferences.BrowseConferences;
public record ConferenceDetailsDto(DateTime StartDate, DateTime EndDate, string Description, bool IsOnline);

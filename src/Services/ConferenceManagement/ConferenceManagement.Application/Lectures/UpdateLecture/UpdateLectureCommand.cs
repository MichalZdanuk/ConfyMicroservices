namespace ConferenceManagement.Application.Lectures.UpdateLecture;
public record UpdateLectureCommand(Guid LectureId, string Title, DateTime StartDate, DateTime EndDate) : ICommand;

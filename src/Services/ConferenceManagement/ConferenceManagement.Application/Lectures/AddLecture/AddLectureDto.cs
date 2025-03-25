namespace ConferenceManagement.Application.Lectures.AddLecture;
public record AddLectureDto(string Title, DateTime StartDate, DateTime EndDate, IList<Guid> PrelegentIds);

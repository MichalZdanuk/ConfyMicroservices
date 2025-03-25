namespace ConferenceManagement.Application.Lectures.UpdateLecturePrelegents;
public record UpdateLecturePrelegentsCommand(Guid LectureId, IList<Guid> PrelegentIds) : ICommand;

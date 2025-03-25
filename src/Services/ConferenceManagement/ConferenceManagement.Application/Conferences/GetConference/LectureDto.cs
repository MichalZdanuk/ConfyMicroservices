namespace ConferenceManagement.Application.Conferences.GetConference;
public record LectureDto(Guid Id, LectureDetailsDto LectureDetails, IList<PrelegentDto> Prelegents);

using ConferenceManagement.Application.Conferences.GetConference;

namespace ConferenceManagement.Application.Conference.GetConference;
public record LectureDto(Guid Id, LectureDetailsDto LectureDetails, IList<PrelegentDto> Prelegents);

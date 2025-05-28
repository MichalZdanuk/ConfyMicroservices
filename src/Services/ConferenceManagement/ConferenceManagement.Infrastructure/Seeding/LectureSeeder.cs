using ConferenceManagement.Domain.ValueObjects;
using Shared.Seeding;

namespace ConferenceManagement.Infrastructure.Seeding;
public static class LectureSeeder
{
	private const int LecturesPerConferenceMin = 1;
	private const int LecturesPerConferenceMax = 5;

	public static async Task SeedLecturesAsync(ConferenceManagementDbContext context)
	{
		var rnd = new Random(SeedConstants.RandomSeed);
		var lectureIds = SeedConstants.LectureIds.ToList();
		int lectureIndex = 0;

		foreach (var conferenceId in SeedConstants.ConferenceIds)
		{
			int lecturesForConference = rnd.Next(LecturesPerConferenceMin, LecturesPerConferenceMax + 1);

			for (int i = 0; i < lecturesForConference && lectureIndex < lectureIds.Count; i++, lectureIndex++)
			{
				var lectureId = lectureIds[lectureIndex];

				var start = new DateTime(2025, 6, 1).AddDays(lectureIndex);
				var end = start.AddHours(1);

				var lecture = Lecture.Create(
					lectureId,
					conferenceId,
					LectureDetails.Of($"Modern .NET Talk #{lectureIndex + 1}", start, end)
				);

				lecture.AddPrelegent(SeedConstants.PrelegentIds[lectureIndex % SeedConstants.PrelegentIds.Length]);

				var conference = await context.Conferences.FirstOrDefaultAsync(c => c.Id == conferenceId);
				if (conference == null)
				{
					throw new Exception($"Conference not found: {conferenceId}");
				}

				conference.AddLecture(lectureId);

				await context.Lectures.AddAsync(lecture);
			}
		}

		await context.SaveChangesAsync();
	}
}

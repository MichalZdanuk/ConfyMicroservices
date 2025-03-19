namespace ConferenceManagement.Domain.ValueObjects;
public record LectureDetails
{
	public string Title { get; } = default!;
	public DateTime StartDate { get; } = default!;
	public DateTime EndDate { get; } = default!;

	protected LectureDetails()
	{
	}

	private LectureDetails(string title,
		DateTime startDate,
		DateTime endDate)
	{
		Title = title;
		StartDate = startDate;
		EndDate = endDate;
	}

	public static LectureDetails Of(string title,
		DateTime startDate,
		DateTime endDate)
	{
		return new LectureDetails(title, startDate, endDate);
	}
}

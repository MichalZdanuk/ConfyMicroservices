namespace ConferenceManagement.Domain.ValueObjects;
public record ConferenceDetails
{
	public DateTime StartDate { get; } = default!;
	public DateTime EndDate { get; } = default!;
	public string Description { get; } = default!;
	public bool IsOnline { get; } = default!;

	protected ConferenceDetails()
	{
	}

	private ConferenceDetails(DateTime startDate,
		DateTime endDate,
		string description,
		bool isOnline)
	{
		StartDate = startDate;
		EndDate = endDate;
		Description = description;
		IsOnline = isOnline;
	}

	public static ConferenceDetails Of(DateTime startDate,
		DateTime endDate,
		string description,
		bool isOnline)
	{
		return new ConferenceDetails(startDate, endDate, description, isOnline);
	}
}

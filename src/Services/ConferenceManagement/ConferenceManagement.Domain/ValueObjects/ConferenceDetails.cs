namespace ConferenceManagement.Domain.ValueObjects;
public record ConferenceDetails
{
	public DateTime StartDate { get; } = default!;
	public DateTime EndDate { get; } = default!;
	public string Description { get; } = default!;

	protected ConferenceDetails()
	{
	}

	private ConferenceDetails(DateTime startDate,
		DateTime endDate,
		string description)
	{
		StartDate = startDate;
		EndDate = endDate;
		Description = description;
	}

	public static ConferenceDetails Of(DateTime startDate,
		DateTime endDate,
		string description)
	{
		return new ConferenceDetails(startDate, endDate, description);
	}
}

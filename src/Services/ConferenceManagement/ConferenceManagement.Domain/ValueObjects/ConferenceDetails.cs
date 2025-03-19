namespace ConferenceManagement.Domain.ValueObjects;
public record ConferenceDetails
{
	public DateTime StartDate { get; } = default!;
	public DateTime EndDate { get; } = default!;
	public string Description { get; } = default!;
}

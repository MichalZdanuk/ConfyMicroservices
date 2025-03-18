namespace ConferenceManagement.Domain.ValueObjects;
public record FullName
{
	public string FirstName { get; } = default!;
	public string LastName { get; } = default!;

	protected FullName()
	{
	}

	private FullName(string firstName, string lastName)
	{
		FirstName = firstName;
		LastName = lastName;
	}

	public static FullName Of(string firstName, string lastName)
	{
		return new FullName(firstName, lastName);
	}
}

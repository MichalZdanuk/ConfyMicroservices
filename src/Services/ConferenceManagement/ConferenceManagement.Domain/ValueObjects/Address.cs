namespace ConferenceManagement.Domain.ValueObjects;
public record Address
{
	public string City { get; } = default!;
	public string Country { get; } = default!;
	public string AddressLine { get; } = default!;
	public string ZipCode { get; } = default!;

	protected Address()
	{
	}

	private Address(string city,
		string country,
		string addressLine,
		string zipCode)
	{
		City = city;
		Country = country;
		AddressLine = addressLine;
		ZipCode = zipCode;
	}

	public static Address Of(string city,
		string country,
		string addressLine,
		string zipCode)
	{
		return new Address(city, country, addressLine, zipCode);
	}
}

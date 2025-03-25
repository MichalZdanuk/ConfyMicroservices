namespace ConferenceManagement.Domain.ValueObjects;
public record ConferenceLinks
{
	public string? WebsiteUrl { get; } = default!;
	public string? FacebookUrl { get; } = default!;
	public string? InstagramUrl { get; } = default!;

	protected ConferenceLinks()
	{
	}

	private ConferenceLinks(string? websiteUrl,
		string? facebookUrl,
		string? instagramUrl)
	{
		WebsiteUrl = websiteUrl;
		FacebookUrl = facebookUrl;
		InstagramUrl = instagramUrl;
	}

	public static ConferenceLinks Of(string? websiteUrl,
		string? facebookUrl,
		string? instagramUrl)
	{
		return new ConferenceLinks(websiteUrl,
			facebookUrl,
			instagramUrl);
	}
}

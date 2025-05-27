using ConferenceManagement.Application.Conferences.CreateConference;
using ConferenceManagement.Application.Conferences.UpdateConfrerence;
using Shared.Enums;

namespace ConfyMicroservices.LoadTests.Utils;
public static class ConferenceDtoFactory
{
	public static CreateConferenceDto PrepareCreateConferenceDto(string name = "TestConf2025")
	{
		return new CreateConferenceDto(
			Name: name,
			ConferenceLanguage: ConferenceLanguage.English,
			ConferenceLinksDto: new CreateConferenceLinksDto(
				WebsiteUrl: "https://testconf.com",
				FacebookUrl: "https://facebook.com/testconf",
				InstagramUrl: "https://instagram.com/testconf"
			),
			ConferenceDetailsDto: new CreateConferenceDetailsDto(
				StartDate: DateTime.UtcNow.AddDays(30),
				EndDate: DateTime.UtcNow.AddDays(33),
				Description: "A test .NET conference for load testing.",
				IsOnline: false
			),
			AddressDto: new CreateAddressDto(
				City: "Testville",
				Country: "Testland",
				AddressLine: "123 Test Ave",
				ZipCode: "12345"
			)
		);
	}

	public static UpdateConferenceDto PrepareUpdateConferenceDto()
	{
		return new UpdateConferenceDto(
			ConferenceLanguage: ConferenceLanguage.English,
			conferenceLinksDto: new UpdateConferenceLinksDto(
				WebsiteUrl: "https://updatedconf.com",
				FacebookUrl: "https://facebook.com/updatedconf",
				InstagramUrl: "https://instagram.com/updatedconf"
			),
			conferenceDetailsDto: new UpdateConferenceDetailsDto(
				Description: "Updated description for the conference.",
				IsOnline: true
			),
			AddressDto: new UpdateAddressDto(
				City: "Updateville",
				Country: "Updateland",
				AddressLine: "456 Update Street",
				ZipCode: "67890"
			)
		);
	}
}

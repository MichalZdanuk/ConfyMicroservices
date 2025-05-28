using Shared.Seeding;
using System.Text;
using System.Text.Json;

namespace ConfyMicroservices.LoadTests.Utils;
public class ConfyScenarioFactory
{
	private const string BaseUrl = "https://localhost:6064";
	private const string AttendeeJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjBmNDQ5M2Q5LWE0NjItNDkyNy1iZTI5LTg0YzgzN2ZhODYzYiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImFhQGFhLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkF0dGVuZGVlIiwiZXhwIjoxNzQ4NDY2MzAzLCJpc3MiOiJBdXRoU2VydmljZSIsImF1ZCI6Ik1pY3Jvc2VydmljZXMifQ.5dX_6CMyA3nQrz4jLlp0xuLtgri1hgEERoZNbGv74WI";
	private const string HostJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImVhNTlkODBmLTMxYzktNGM2Ni1hNTZiLTdhZWNkM2FkYzdlYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6Imhvc3RAY29uZnkuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiSG9zdCIsImV4cCI6MTc0ODQ2NjI3NiwiaXNzIjoiQXV0aFNlcnZpY2UiLCJhdWQiOiJNaWNyb3NlcnZpY2VzIn0.BkXnIpnw_6Fm0jNZEAkJ6DW0qS4pC6I5saoXilFITYw";
	private Guid ConferenceId = SeedConstants.ConferenceIds[1];
	private const int WarmUpDurationSeconds = 3;

	public ScenarioProps PrepareGetConferenceScenario(string scenarioName, HttpClient httpClient, LoadSimulation simulation)
	{
		var url = $"{BaseUrl}/conferencemanagement-service/conferences/{ConferenceId}";

		return Scenario.Create(scenarioName, async context =>
		{
			var getConference = await Step.Run("getConference", context, async () =>
			{
				var request = Http.CreateRequest("GET", url)
					.WithHeader("Accept", "application/json")
					.WithHeader("Authorization", $"Bearer {AttendeeJwtToken}");

				var response = await Http.Send(httpClient, request);
				return Response.Ok(response);
			});

			return getConference;
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(WarmUpDurationSeconds))
		.WithLoadSimulations(simulation);
	}

	public ScenarioProps PrepareBrowseConferencesScenario(string scenarioName, HttpClient httpClient, LoadSimulation simulation)
	{
		var url = $"{BaseUrl}/conferencemanagement-service/conferences";

		return Scenario.Create(scenarioName, async context =>
		{
			var browseConferences = await Step.Run("browseConferences", context, async () =>
			{
				var request = Http.CreateRequest("GET", url)
					.WithHeader("Accept", "application/json")
					.WithHeader("Authorization", $"Bearer {AttendeeJwtToken}");

				var response = await Http.Send(httpClient, request);
				return Response.Ok(response);
			});

			return browseConferences;
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(WarmUpDurationSeconds))
		.WithLoadSimulations(simulation);
	}

	public ScenarioProps PrepareCreateConferenceScenario(string scenarioName, HttpClient httpClient, LoadSimulation simulation)
	{
		var url = $"{BaseUrl}/conferencemanagement-service/conferences";

		return Scenario.Create(scenarioName, async context =>
		{
			var createConference = await Step.Run("createConference", context, async () =>
			{
				var dto = ConferenceDtoFactory.PrepareCreateConferenceDto($"Conf_{Guid.NewGuid()}");
				var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

				var request = Http.CreateRequest("POST", url)
					.WithHeader("Accept", "application/json")
					.WithHeader("Authorization", $"Bearer {HostJwtToken}")
					.WithBody(jsonContent);

				var response = await Http.Send(httpClient, request);
				return Response.Ok(response);
			});

			return createConference;
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(WarmUpDurationSeconds))
		.WithLoadSimulations(simulation);
	}

	public ScenarioProps PrepareUpdateConferenceScenario(string scenarioName, HttpClient httpClient, LoadSimulation simulation)
	{
		var url = $"{BaseUrl}/conferencemanagement-service/conferences/{ConferenceId.ToString()}";

		return Scenario.Create(scenarioName, async context =>
		{
			var updateConference = await Step.Run("updateConference", context, async () =>
			{
				var dto = ConferenceDtoFactory.PrepareUpdateConferenceDto();
				var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

				var request = Http.CreateRequest("PUT", url)
					.WithHeader("Accept", "application/json")
					.WithHeader("Authorization", $"Bearer {HostJwtToken}")
					.WithBody(jsonContent);

				var response = await Http.Send(httpClient, request);
				return Response.Ok(response);
			});

			return updateConference;
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(WarmUpDurationSeconds))
		.WithLoadSimulations(simulation);
	}
}

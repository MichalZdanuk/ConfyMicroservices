using Shared.Seeding;
using System.Text;
using System.Text.Json;

namespace ConfyMicroservices.LoadTests.Utils;
public class ConfyScenarioFactory
{
	private const string BaseUrl = "https://localhost:6064";
	private const string AttendeeJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Ijg0OWNmMmYwLWRmYjktNDJmOS05NWRmLWQ1MTY1ODJjMjViZiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImFhQGFhLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkF0dGVuZGVlIiwiZXhwIjoxNzQ4NDYzMjk5LCJpc3MiOiJBdXRoU2VydmljZSIsImF1ZCI6Ik1pY3Jvc2VydmljZXMifQ.0VVOHxa41F6gqWEGpi4QrZD3602ErmcRCSEp8aXlXrI";
	private const string HostJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI3ZGE2YzA5LTk3NzItNGFmMS04ZTI2LWQ5MjQ5NzUzNjJiYiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6Im1hcnRpbkBmb3dsZXIuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiSG9zdCIsImV4cCI6MTc0Nzc4MjI5MywiaXNzIjoiQ29uZnlNb25vbGl0aCIsImF1ZCI6IkNvbmZ5TW9ub2xpdGgifQ.ttmBTfEF8al9mIy_0qyrD1-AifS6mV2OWQCJ7Oq6kiY";
	private Guid ConferenceId = SeedConstants.ConferenceIds[1];
	private const int WarmUpDurationSeconds = 2;

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

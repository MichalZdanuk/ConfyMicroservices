namespace ConfyMicroservices.LoadTests.Tests;
public class UpdateConferenceTests
{
	[Fact]
	public void Update_Conference_ConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"update_conference_vu_{LoadTestSettings.VirtualUsersCount}_mode_{LoadTestSettings.KeepConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			LoadTestSettings.VirtualUsersCount,
			LoadTestSettings.KeepConstantMode,
			httpClient => scenarioFactory.PrepareUpdateConferenceScenario(scenarioName,
				httpClient,
				Simulation.KeepConstant(LoadTestSettings.VirtualUsersCount, TimeSpan.FromSeconds(LoadTestSettings.SimulationDurationSeconds))),
			LoadTestSettings.RunCount);

		metrics.Print();
	}

	[Fact]
	public void Update_Conference_RampingConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"update_conference_vu_{LoadTestSettings.VirtualUsersCount}_mode_{LoadTestSettings.RampingConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			LoadTestSettings.VirtualUsersCount,
			LoadTestSettings.RampingConstantMode,
			httpClient => scenarioFactory.PrepareUpdateConferenceScenario(scenarioName,
				httpClient,
				Simulation.RampingConstant(LoadTestSettings.VirtualUsersCount,
				TimeSpan.FromSeconds(LoadTestSettings.SimulationDurationSeconds))),
			LoadTestSettings.RunCount);

		metrics.Print();
	}
}

namespace ConfyMicroservices.LoadTests.Tests;
public class CreateConferenceTests
{
	[Fact]
	public void Create_Conference_ConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"create_conference_vu_{LoadTestSettings.VirtualUsersCount}_mode_{LoadTestSettings.KeepConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			LoadTestSettings.VirtualUsersCount,
			LoadTestSettings.KeepConstantMode,
			httpClient => scenarioFactory.PrepareCreateConferenceScenario(scenarioName,
				httpClient, Simulation.KeepConstant(LoadTestSettings.VirtualUsersCount, TimeSpan.FromSeconds(LoadTestSettings.SimulationDurationSeconds))),
			LoadTestSettings.RunCount);

		metrics.Print();
	}

	[Fact]
	public void Create_Conference_RampingConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"create_conference_vu_{LoadTestSettings.VirtualUsersCount}_mode_{LoadTestSettings.RampingConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			LoadTestSettings.VirtualUsersCount,
			LoadTestSettings.RampingConstantMode,
			httpClient => scenarioFactory.PrepareCreateConferenceScenario(scenarioName,
				httpClient,
				Simulation.RampingConstant(LoadTestSettings.VirtualUsersCount, TimeSpan.FromSeconds(LoadTestSettings.SimulationDurationSeconds))),
			LoadTestSettings.RunCount);

		metrics.Print();
	}
}

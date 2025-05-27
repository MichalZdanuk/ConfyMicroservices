namespace ConfyMicroservices.LoadTests.Tests;
public class GetConferenceByIdTests
{
	[Fact]
	public void Get_Conference_ById_ConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"get_conference_by_id_vu_{LoadTestSettings.VirtualUsersCount}_mode_{LoadTestSettings.KeepConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			LoadTestSettings.VirtualUsersCount,
			LoadTestSettings.KeepConstantMode,
			httpClient => scenarioFactory.PrepareGetConferenceScenario(scenarioName,
				httpClient,
				Simulation.KeepConstant(LoadTestSettings.VirtualUsersCount, TimeSpan.FromSeconds(LoadTestSettings.SimulationDurationSeconds))),
			LoadTestSettings.RunCount);

		metrics.Print();
	}

	[Fact]
	public void Get_Conference_ById_RampingConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"get_conference_by_id_vu_{LoadTestSettings.VirtualUsersCount}_mode_{LoadTestSettings.RampingConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			LoadTestSettings.VirtualUsersCount,
			LoadTestSettings.RampingConstantMode,
			httpClient => scenarioFactory.PrepareGetConferenceScenario(scenarioName,
				httpClient,
				Simulation.RampingConstant(LoadTestSettings.VirtualUsersCount, TimeSpan.FromSeconds(LoadTestSettings.SimulationDurationSeconds))),
			LoadTestSettings.RunCount);

		metrics.Print();
	}
}

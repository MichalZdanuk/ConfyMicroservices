using NBomber.Contracts.Stats;

namespace ConfyMicroservices.LoadTests.Utils;
public static class LoadTestHelper
{
	public static ScenarioMetrics RunScenarioMultipleTimes(
		string scenarioName,
		int virtualUsersCount,
		string simulationMode,
		Func<HttpClient, ScenarioProps> scenarioFactory,
		int runCount = 3)
	{
		var allStats = new List<ScenarioStats[]>();

		for (int i = 0; i < runCount; i++)
		{
			using var httpClient = new HttpClient();

			var customSink = new MyCustomSink();
			var scenario = scenarioFactory(httpClient);

			NBomberRunner
				.RegisterScenarios(scenario)
				.WithReportingSinks(customSink)
				.WithReportFileName($"{scenarioName}_run_vu_{virtualUsersCount}_mode_{simulationMode}_{i + 1}")
				.WithReportFormats(ReportFormat.Txt, ReportFormat.Html, ReportFormat.Csv)
				.Run();

			allStats.AddRange(customSink.GetCollectedStats());
		}

		var scenarioStats = allStats
			.SelectMany(statsList => statsList)
			.Where(s => s.ScenarioName == scenarioName)
			.ToList();

		var rpsList = scenarioStats.Select(s => s.Ok.Request.RPS).ToList();
		var okList = scenarioStats.Select(s => (double)s.Ok.Request.Count).ToList();
		var failList = scenarioStats.Select(s => (double)s.Fail.Request.Count).ToList();

		var totalOkCount = scenarioStats.Sum(s => s.Ok.Request.Count);
		var weightedLatencySum = scenarioStats.Sum(s => s.Ok.Latency.MeanMs * s.Ok.Request.Count);
		var weightedMeanLatency = totalOkCount > 0 ? weightedLatencySum / totalOkCount : 0;

		return new ScenarioMetrics
		{
			ScenarioName = scenarioName,
			VirtualUsersCount = virtualUsersCount,
			SimulationMode = simulationMode,
			AverageRps = rpsList.Average(),
			AverageOk = okList.Average(),
			AverageFail = failList.Average(),
			WeightedMeanLatency = weightedMeanLatency,
			GlobalMinLatency = scenarioStats.Min(s => s.Ok.Latency.MinMs),
			GlobalMaxLatency = scenarioStats.Max(s => s.Ok.Latency.MaxMs),
		};
	}
}

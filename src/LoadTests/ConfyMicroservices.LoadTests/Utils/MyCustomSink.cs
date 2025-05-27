using Microsoft.Extensions.Configuration;
using NBomber.Contracts.Stats;

namespace ConfyMicroservices.LoadTests.Utils;
public class MyCustomSink : IReportingSink
{
	public string SinkName => "MyCustomSink";
	private List<ScenarioStats[]> _allRunStats = new();

	public void Dispose() { }

	public Task Init(IBaseContext context, IConfiguration infraConfig)
	{
		_allRunStats = new List<ScenarioStats[]>();
		return Task.CompletedTask;
	}

	public Task SaveRealtimeStats(ScenarioStats[] stats)
	{
		return Task.CompletedTask;
	}

	public Task SaveFinalStats(NodeStats stats)
	{
		_allRunStats.Add(stats.ScenarioStats);
		return Task.CompletedTask;
	}

	public Task Start(SessionStartInfo sessionInfo) => Task.CompletedTask;

	public Task Stop()
	{
		return Task.CompletedTask;
	}

	public List<ScenarioStats[]> GetCollectedStats() => _allRunStats;
}

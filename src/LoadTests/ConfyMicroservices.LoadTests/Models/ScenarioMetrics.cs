namespace ConfyMicroservices.LoadTests.Models;
public class ScenarioMetrics
{
	public string ScenarioName { get; set; } = default!;
	public int VirtualUsersCount { get; set; }
	public string SimulationMode { get; set; } = default!;

	public double AverageRps { get; set; }
	public double AverageOk { get; set; }
	public double AverageFail { get; set; }
	public double WeightedMeanLatency { get; set; }
	public double GlobalMinLatency { get; set; }
	public double GlobalMaxLatency { get; set; }

	public void Print()
	{
		Console.WriteLine($"------ Aggregated Metrics for: {ScenarioName}; VU: {VirtualUsersCount}, Mode: {SimulationMode} ------");
		Console.WriteLine($"Average RPS: {AverageRps:F2}");
		Console.WriteLine($"Average OK Requests: {AverageOk:F2}");
		Console.WriteLine($"Average Failed Requests: {AverageFail:F2}");
		Console.WriteLine($"Weighted Mean Latency (ms): {WeightedMeanLatency:F2}");
		Console.WriteLine($"Global Min Latency (ms): {GlobalMinLatency}");
		Console.WriteLine($"Global Max Latency (ms): {GlobalMaxLatency}");
		Console.WriteLine("-----------------------------------------------------");
	}
}

namespace ConfyMicroservices.LoadTests.Settings;
public static class LoadTestSettings
{
	public const int RunCount = 3;
	public const int SimulationDurationSeconds = 5;
	public const int VirtualUsersCount = 50;

	public const string KeepConstantMode = "KeepConstant";
	public const string RampingConstantMode = "RampingConstant";
}

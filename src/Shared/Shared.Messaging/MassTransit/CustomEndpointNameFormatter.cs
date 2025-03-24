using MassTransit;

namespace Shared.Messaging.MassTransit;
public class CustomEndpointNameFormatter : KebabCaseEndpointNameFormatter
{
	private readonly string _prefix;

	public CustomEndpointNameFormatter(string prefix, bool includeNamespace = false)
		: base(includeNamespace)
	{
		_prefix = prefix.ToLower().Replace(".", "-");
	}

	public override string Consumer<T>()
	{
		return $"{_prefix}-{base.Consumer<T>()}";
	}

	public override string Saga<T>()
	{
		return $"{_prefix}-{base.Saga<T>()}";
	}

	public override string ExecuteActivity<T, TArguments>()
	{
		return $"{_prefix}-{base.ExecuteActivity<T, TArguments>()}";
	}
}

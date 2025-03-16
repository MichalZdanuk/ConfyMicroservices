namespace Shared.Context;
public interface IContext
{
	Guid UserId { get; }
	string Role { get; }
}

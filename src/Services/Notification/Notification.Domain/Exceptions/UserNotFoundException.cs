using Shared.Exceptions;

namespace Notification.Domain.Exceptions;
public class UserNotFoundException
	: NotFoundException
{
	public UserNotFoundException(Guid userId) : base($"User with id: {userId} was not found")
	{
	}
}

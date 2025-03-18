using Shared.Domain;
using Shared.Enums;

namespace ConferenceManagement.Domain.Entities;
public class User : Entity
{
	public string Email { get; private set; } = string.Empty;
	public UserRole UserRole { get; private set; }

	public static User Create(string email,
		string passwordHash, UserRole userRole)
	{
		return new User()
		{
			Id = Guid.NewGuid(),
			Email = email,
			UserRole = userRole,
		};
	}
}

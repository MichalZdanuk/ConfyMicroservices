using Authentication.API.ValueObjects;
using Shared.Domain;
using Shared.Enums;

namespace Authentication.API.Entities;

public class User : Entity
{
	public FullName FullName { get; private set; } = default!;
	public string Email { get; private set; } = string.Empty;
	public string PasswordHash { get; private set; } = string.Empty;
	public string? Bio { get; private set; }
	public UserRole UserRole { get; private set; }

	public static User Create(Guid id,
		string email,
		string passwordHash,
		FullName fullName,
		UserRole userRole,
		string? bio = null)
	{
		return new User()
		{
			Id = id,
			Email = email,
			PasswordHash = passwordHash,
			FullName = fullName,
			UserRole = userRole,
			Bio = bio,
		};
	}
}

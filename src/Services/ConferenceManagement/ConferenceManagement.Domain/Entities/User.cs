using ConferenceManagement.Domain.ValueObjects;
using Shared.Domain;
using Shared.Enums;

namespace ConferenceManagement.Domain.Entities;
public class User : Entity
{
	public FullName FullName { get; private set; } = default!;
	public string Email { get; private set; } = string.Empty;
	public UserRole UserRole { get; private set; }

	public static User Create(Guid id,
		FullName fullName,
		string email,
		UserRole userRole)
	{
		return new User()
		{
			Id = id,
			FullName = fullName,
			Email = email,
			UserRole = userRole,
		};
	}
}

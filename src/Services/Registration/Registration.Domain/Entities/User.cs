using Shared.Domain;

namespace Registration.Domain.Entities;
public class User : Entity
{
	public string Email { get; set; } = default!;

	public static User Create(Guid id,
		string email)
	{
		return new User()
		{
			Id = id,
			Email = email,
		};
	}
}

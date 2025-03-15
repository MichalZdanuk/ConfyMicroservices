using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Enums;

namespace Shared.Infrastructure;
public class UserRoleEnumConverter
	: ValueConverter<UserRole, string>
{
	public UserRoleEnumConverter() : base(
			v => v.ToString(),
			v => (UserRole)Enum.Parse(typeof(UserRole), v))
	{ }
}

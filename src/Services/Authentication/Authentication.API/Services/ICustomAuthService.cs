using Authentication.API.Authentication.Register;
using Shared.Enums;

namespace Authentication.API.Services;

public interface ICustomAuthService
{
	public Task<User> Register(string FirstName, string LastName, string Email, string Password, UserRole UserRole);
	public Task<string> Login(string email, string password);
}

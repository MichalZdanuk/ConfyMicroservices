using Authentication.API.Authentication.Register;

namespace Authentication.API.Services;

public interface ICustomAuthService
{
	public Task<User> Register(RegisterCommand registerCommand);
	public Task<string> Login(string email, string password);
}

namespace Authentication.API.Services;

public interface ICustomAuthService
{
	public Task<User> Register(string email, string password);
	public Task<string> Login(string email, string password);
}

using Authentication.API.Services;

namespace Authentication.API.Authentication.Login;

public class LoginQueryHandler(ICustomAuthService customAuthService)
	: IRequestHandler<LoginQuery, LoginResponse>
{
	public async Task<LoginResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
	{
		var token = await customAuthService.Login(query.Email, query.Password);

		return new LoginResponse(token);
	}
}

using Authentication.API.Services;
using MediatR;

namespace Authentication.API.Authentication.Login;

public class LoginCommandHandler(ICustomAuthService customAuthService)
	: IRequestHandler<LoginCommand, LoginResponse>
{
	public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
	{
		var token = await customAuthService.Login(command.Email, command.Password);

		return new LoginResponse(token);
	}
}

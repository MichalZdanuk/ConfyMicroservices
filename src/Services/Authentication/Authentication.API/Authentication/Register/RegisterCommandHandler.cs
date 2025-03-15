using Authentication.API.Services;

namespace Authentication.API.Authentication.Register;

public class RegisterCommandHandler(ICustomAuthService customAuthService)
	: IRequestHandler<RegisterCommand>
{
	public async Task Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		await customAuthService.Register(command.Email, command.Password);
	}
}

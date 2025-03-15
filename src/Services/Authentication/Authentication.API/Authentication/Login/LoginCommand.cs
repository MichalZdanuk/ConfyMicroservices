namespace Authentication.API.Authentication.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;

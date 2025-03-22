using Shared.CQRS;

namespace Authentication.API.Authentication.Login;

public record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;

namespace Authentication.API.Authentication.Login;

public record LoginQuery(string Email, string Password) : IQuery<LoginResponse>;

using Shared.Enums;

namespace Authentication.API.Authentication.Create;

public record CreateUserCommand(string FirstName, string LastName, string Bio, string Email, string Password, UserRole UserRole) : ICommand;

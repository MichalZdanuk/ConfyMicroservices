using MediatR;

namespace Authentication.API.Authentication.Register;

public record RegisterCommand(string Email, string Password) : IRequest;

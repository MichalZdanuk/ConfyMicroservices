﻿namespace Authentication.API.Authentication.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest;

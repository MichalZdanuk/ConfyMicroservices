namespace Authentication.API.Exceptions;

public class EmailAlreadyTakenException(string email)
	: BadRequestException($"Email: {email} is already taken.")
{
}

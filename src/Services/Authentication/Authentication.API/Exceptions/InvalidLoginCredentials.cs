namespace Authentication.API.Exceptions;

public class InvalidLoginCredentials()
	: BadRequestException("Invalid login credentials")
{
}

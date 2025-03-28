namespace Registration.Domain.Exceptions;
public class RegistrationNotFoundException
	: NotFoundException
{
	public RegistrationNotFoundException(Guid registrationId) : base($"Registration with id: {registrationId} was not found")
	{
	}
}

namespace Registration.Domain.Entities;
public class Registration : Aggregate
{
	public Guid UserId { get; private set; }
	public Guid ConferenceId { get; private set; }
	public Conference Conference { get; private set; }
	public RegistrationStatus RegistrationStatus { get; private set; }

	private Registration()
	{
	}

	private Registration(Guid userId, Guid conferenceId, Conference conference)
	{
		Id = Guid.NewGuid();
		UserId = userId;
		ConferenceId = conferenceId;
		Conference = conference;
		RegistrationStatus = RegistrationStatus.Registered;

		AddDomainEvent(new UserRegisteredForConferenceEvent(userId, conferenceId, conference.Name));
	}

	public static Registration Create(Guid userId, Guid conferenceId, Conference conference)
	{
		if (conference.StartDate <= DateTime.UtcNow)
		{
			throw new CannotRegisterAfterStartOfConferenceException(conferenceId);
		}

		return new Registration(userId, conferenceId, conference);
	}

	public void Cancel()
	{
		if (RegistrationStatus == RegistrationStatus.Canceled)
		{
			throw new CannotCancelAlreadyCancelledRegistrationException(ConferenceId);
		}

		if (Conference.StartDate <= DateTime.UtcNow)
		{
			throw new CannotCancelAfterStartOfConferenceException();
		}

		RegistrationStatus = RegistrationStatus.Canceled;

		AddDomainEvent(new RegistrationForConferenceCanceledEvent(UserId, ConferenceId, Conference.Name));
	}

	public void ReRegister()
	{
		if(RegistrationStatus != RegistrationStatus.Canceled)
		{
			throw new CannotReRegisterForNotCancelledConferenceRegistrationException(ConferenceId);
		}

		if (Conference.StartDate <= DateTime.UtcNow)
		{
			throw new CannotReRegisterForAlreadyStartedConferenceException(ConferenceId);
		}

		RegistrationStatus = RegistrationStatus.Registered;

		AddDomainEvent(new UserReRegisteredForConferenceEvent(UserId, ConferenceId, Conference.Name));
	}
}

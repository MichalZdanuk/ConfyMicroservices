﻿namespace ConferenceManagement.Domain.Repositories;
public interface IUserRepository
{
	public Task AddAsync(User user);
}

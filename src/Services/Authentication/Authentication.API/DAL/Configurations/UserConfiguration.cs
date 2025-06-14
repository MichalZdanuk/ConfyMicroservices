﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure;

namespace Authentication.API.DAL.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>,
	IEntityTypeConfiguration<User>
{
	public override void Configure(EntityTypeBuilder<User> builder)
	{
		base.Configure(builder);

		builder.ToTable("Users");

		builder.Property(u => u.Email)
			.IsRequired();

		builder.Property(u => u.Bio)
			.IsRequired(false);

		builder.Property(u => u.PasswordHash)
			.IsRequired();

		builder.Property(u => u.UserRole)
			.IsRequired()
			.HasConversion(new UserRoleEnumConverter());

		builder.ComplexProperty(
			u => u.FullName, fullNameBuilder =>
			{
				fullNameBuilder.Property(f => f.FirstName)
					.IsRequired();

				fullNameBuilder.Property(f => f.LastName)
					.IsRequired();
			});
	}
}

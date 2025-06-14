﻿namespace Notification.Infrastructure.Configurations;
public class UserConfiguration
	: BaseEntityConfiguration<User>, IEntityTypeConfiguration<User>
{
	public override void Configure(EntityTypeBuilder<User> builder)
	{
		base.Configure(builder);

		builder.ToTable("Users");

		builder.Property(u => u.Email)
			.IsRequired();

		builder.HasMany<Domain.Entities.Notification>()
			.WithOne()
			.HasForeignKey(r => r.UserId);
	}
}

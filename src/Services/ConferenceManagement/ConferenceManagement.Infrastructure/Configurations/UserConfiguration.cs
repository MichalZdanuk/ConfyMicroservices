using ConferenceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure;

namespace ConferenceManagement.Infrastructure.Configurations;
public class UserConfiguration : BaseEntityConfiguration<User>,
	IEntityTypeConfiguration<User>
{
	public override void Configure(EntityTypeBuilder<User> builder)
	{
		base.Configure(builder);

		builder.ToTable("Users");

		builder.Property(u => u.Email)
			.IsRequired();

		builder.Property(u => u.UserRole)
			.IsRequired()
			.HasConversion(new UserRoleEnumConverter());
	}
}

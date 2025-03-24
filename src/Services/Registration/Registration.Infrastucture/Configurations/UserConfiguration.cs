using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.Entities;
using Shared.Infrastructure;

namespace Registration.Infrastucture.Configurations;
public class UserConfiguration
	: BaseEntityConfiguration<User>, IEntityTypeConfiguration<User>
{
	public override void Configure(EntityTypeBuilder<User> builder)
	{
		base.Configure(builder);

		builder.ToTable("Users");

		builder.Property(u => u.Email)
			.IsRequired();
	}
}

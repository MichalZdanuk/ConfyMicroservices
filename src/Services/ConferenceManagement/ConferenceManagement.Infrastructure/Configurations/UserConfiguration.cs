using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

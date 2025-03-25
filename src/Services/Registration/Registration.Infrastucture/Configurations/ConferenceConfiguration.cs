using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.Entities;
using Shared.Infrastructure;

namespace Registration.Infrastucture.Configurations;
public class ConferenceConfiguration
	: BaseEntityConfiguration<Conference>, IEntityTypeConfiguration<Conference>
{
	public override void Configure(EntityTypeBuilder<Conference> builder)
	{
		base.Configure(builder);

		builder.ToTable("Conferences");

		builder.Property(u => u.StartDate)
			.IsRequired();

		builder.Property(u => u.EndDate)
			.IsRequired();

		builder.Property(u => u.Name)
			.IsRequired();
	}
}

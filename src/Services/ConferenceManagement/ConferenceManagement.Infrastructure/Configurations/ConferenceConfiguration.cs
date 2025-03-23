using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceManagement.Infrastructure.Configurations;
public class ConferenceConfiguration
	: BaseEntityConfiguration<Conference>,
	IEntityTypeConfiguration<Conference>
{
	public override void Configure(EntityTypeBuilder<Conference> builder)
	{
		base.Configure(builder);

		builder.ToTable("Conferences");

		builder.Property(c => c.Name)
			.IsRequired();

		builder.ComplexProperty(c => c.ConferenceDetails, conferenceDetailsBuilder =>
		{
			conferenceDetailsBuilder.Property(c => c.StartDate).IsRequired();
			conferenceDetailsBuilder.Property(c => c.EndDate).IsRequired();
			conferenceDetailsBuilder.Property(c => c.Description).IsRequired();
		});

		builder.ComplexProperty(c => c.Address, addressBuilder =>
		{
			addressBuilder.Property(a => a.City).IsRequired();
			addressBuilder.Property(a => a.Country).IsRequired();
			addressBuilder.Property(a => a.AddressLine).IsRequired();
			addressBuilder.Property(a => a.ZipCode).IsRequired();
		});

		builder.HasMany<Lecture>()
			.WithOne()
			.HasForeignKey(l => l.ConferenceId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}

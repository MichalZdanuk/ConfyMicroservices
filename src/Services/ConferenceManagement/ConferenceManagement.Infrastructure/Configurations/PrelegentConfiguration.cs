using ConferenceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;

namespace ConferenceManagement.Infrastructure.Configurations;
public class PrelegentConfiguration
	: BaseEntityConfiguration<Prelegent>,
	IEntityTypeConfiguration<Prelegent>
{
	public override void Configure(EntityTypeBuilder<Prelegent> builder)
	{
		base.Configure(builder);

		builder.ToTable("Prelegents");

		builder.Property(p => p.Name)
			.IsRequired()
			.HasMaxLength(200);

		builder.Property(p => p.Bio)
			.IsRequired()
			.HasMaxLength(1000);
	}
}

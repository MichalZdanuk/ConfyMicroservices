using ConferenceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure;

namespace ConferenceManagement.Infrastructure.Configurations;
public class LectureAssignmentConfiguration
	: BaseEntityConfiguration<LectureAssignment>,
	IEntityTypeConfiguration<LectureAssignment>
{
	public override void Configure(EntityTypeBuilder<LectureAssignment> builder)
	{
		base.Configure(builder);

		builder.ToTable("LectureAssignments");

		builder.Property(la => la.LectureId)
			.IsRequired();

		builder.Property(la => la.PrelegentId)
			.IsRequired();
	}
}

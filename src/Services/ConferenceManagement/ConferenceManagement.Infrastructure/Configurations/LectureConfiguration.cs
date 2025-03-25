namespace ConferenceManagement.Infrastructure.Configurations;
public class LectureConfiguration
	: BaseEntityConfiguration<Lecture>,
	IEntityTypeConfiguration<Lecture>
{
	public override void Configure(EntityTypeBuilder<Lecture> builder)
	{
		base.Configure(builder);

		builder.ToTable("Lectures");

		builder.Property(l => l.ConferenceId)
			.IsRequired();

		builder.OwnsOne(l => l.LectureDetails, details =>
		{
			details.Property(d => d.Title).IsRequired();
			details.Property(d => d.StartDate).IsRequired();
			details.Property(d => d.EndDate).IsRequired();
		});

		builder.HasMany(l => l.LectureAssignments)
			.WithOne()
			.HasForeignKey(assignment => assignment.LectureId);
	}
}

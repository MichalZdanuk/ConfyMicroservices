
using Notification.Infrastructure.Converters;

namespace Notification.Infrastructure.Configurations;
public class NotificationConfiguration
	: BaseEntityConfiguration<Domain.Entities.Notification>, IEntityTypeConfiguration<Domain.Entities.Notification>
{
	public override void Configure(EntityTypeBuilder<Domain.Entities.Notification> builder)
	{
		base.Configure(builder);

		builder.ToTable("Notifications");

		builder.Property(n => n.NotificationStatus)
			.HasConversion(new NotificationStatusEnumConverter())
			.IsRequired();

		builder.Property(n => n.NotificationType)
			.HasConversion(new NotificationTypeEnumConverter())
			.IsRequired();

		builder.Property(n => n.Content)
			.IsRequired();

		builder.Property(n => n.SentAt)
			.IsRequired(false);
	}
}

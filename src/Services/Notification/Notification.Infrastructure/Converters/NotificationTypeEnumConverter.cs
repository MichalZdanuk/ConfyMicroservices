using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notification.Domain.Enums;

namespace Notification.Infrastructure.Converters;
public class NotificationTypeEnumConverter
	: ValueConverter<NotificationType, string>
{
	public NotificationTypeEnumConverter() : base(
			v => v.ToString(),
			v => (NotificationType)Enum.Parse(typeof(NotificationType), v))
	{ }
}

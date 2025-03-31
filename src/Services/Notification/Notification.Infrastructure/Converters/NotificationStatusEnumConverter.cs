using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notification.Domain.Enums;

namespace Notification.Infrastructure.Converters;
public class NotificationStatusEnumConverter
	: ValueConverter<NotificationStatus, string>
{
	public NotificationStatusEnumConverter() : base(
			v => v.ToString(),
			v => (NotificationStatus)Enum.Parse(typeof(NotificationStatus), v))
	{ }
}
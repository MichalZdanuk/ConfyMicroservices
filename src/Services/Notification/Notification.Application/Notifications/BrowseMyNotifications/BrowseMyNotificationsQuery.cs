using Shared.CQRS;
using Shared.Pagination;

namespace Notification.Application.Notifications.BrowseMyNotifications;
public record BrowseMyNotificationsQuery(PaginationRequest Pagination) : IQuery<PaginationResult<NotificationDto>>;

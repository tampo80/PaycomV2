using PayCom.Blazor.Shared.Notifications;
using MediatR;

namespace PayCom.Blazor.Infrastructure.Notifications;

public class NotificationWrapper<TNotificationMessage> : INotification
    where TNotificationMessage : INotificationMessage
{
    public NotificationWrapper(TNotificationMessage notification) => Notification = notification;

    public TNotificationMessage Notification { get; }
}

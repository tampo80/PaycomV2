using PayCom.Blazor.Shared.Notifications;

namespace PayCom.Blazor.Infrastructure.Notifications;

public interface INotificationPublisher
{
    Task PublishAsync(INotificationMessage notification);
}

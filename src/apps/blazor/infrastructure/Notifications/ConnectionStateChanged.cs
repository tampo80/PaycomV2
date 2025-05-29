using PayCom.Blazor.Shared.Notifications;

namespace PayCom.Blazor.Infrastructure.Notifications;

public record ConnectionStateChanged(ConnectionState State, string? Message) : INotificationMessage;

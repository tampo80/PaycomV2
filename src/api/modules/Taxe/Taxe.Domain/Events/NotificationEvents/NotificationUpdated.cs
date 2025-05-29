using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.NotificationEvents;

public sealed record NotificationUpdated : DomainEvent
{
    public Notification? Notification { get; set; }
}

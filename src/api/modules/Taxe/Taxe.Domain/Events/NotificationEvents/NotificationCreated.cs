using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.NotificationEvents;

public sealed record NotificationCreated : DomainEvent
{
    public Notification? Notification { get; set; }
}

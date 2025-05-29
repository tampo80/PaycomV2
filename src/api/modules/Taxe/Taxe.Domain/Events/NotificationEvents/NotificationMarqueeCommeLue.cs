using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Taxe.Domain.Events.NotificationEvents;

public record NotificationMarqueeCommeLue : DomainEvent
{
    public Notification Notification { get; init; } = default!;
} 

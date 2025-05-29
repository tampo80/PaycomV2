using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.ZoneCollecteEvents;

public record ZoneCollecteUpdated : DomainEvent
{
    public ZoneCollecte ZoneCollecte { get; init; } = default!;
} 

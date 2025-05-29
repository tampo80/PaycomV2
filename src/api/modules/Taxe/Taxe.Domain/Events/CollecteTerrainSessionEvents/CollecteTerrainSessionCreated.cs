using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.CollecteTerrainSessionEvents;

public record CollecteTerrainSessionCreated : DomainEvent
{
    public CollecteTerrainSession Session { get; init; } = default!;
} 

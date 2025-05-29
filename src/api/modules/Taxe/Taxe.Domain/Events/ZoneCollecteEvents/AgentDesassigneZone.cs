using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.ZoneCollecteEvents;

public record AgentDesassigneZone : DomainEvent
{
    public ZoneCollecte ZoneCollecte { get; init; } = default!;
    public AgentFiscal AgentFiscal { get; init; } = default!;
} 

using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.ZoneCollecteEvents;

public record AgentAssigneZone : DomainEvent
{
    public ZoneCollecte ZoneCollecte { get; init; } = default!;
    public AgentFiscal AgentFiscal { get; init; } = default!;
} 

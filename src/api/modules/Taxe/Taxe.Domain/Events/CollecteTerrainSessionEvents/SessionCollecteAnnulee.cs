using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.CollecteTerrainSessionEvents;

public record SessionCollecteAnnulee : DomainEvent
{
    public CollecteTerrainSession Session { get; init; } = default!;
    public string Raison { get; init; } = string.Empty;
} 
